import sys, subprocess, io, os, json, copy, time, psutil
from shutil import copyfile

dataPath = "./data/"
imagePath = "./images/"
modPath = "./mods"
baseContentList = [
    "ads.json",
    "conditions_simple.json",
    "crewskins.json",
    "installables.json",
    "lights.json",
    "names_ship_gennoun.json",
    "traitscores.json",
    "audioemitters.json",
    "condowners.json",
    "gasrespires.json",
    "interactions2.json",
    "loot.json",
    "names_ship.json",
    "slots.json",
    "careers.json",
    "condrules.json",
    "guipropmaps.json",
    "interactions.json",
    "music.json",
    "personspecs.json",
    "strings.json",
    "colors.json",
    "condtrigs2.json",
    "headlines.json",
    "interactionsSocialCombat.json",
    "names_first.json",
    "plots.json",
    "tasks.json",
    "computerentries.json",
    "condtrigs.json",
    "homeworlds.json",
    "items.json",
    # "names_last.json",
    "powerinfos.json",
    "testButtonJSONSchema.json",
    "conditions.json",
    "cooverlays.json",
    # "IAHistory.csv",
    "lifeevents.json",
    "names_ship_genadj.json",
    "roles.json",
    "tickers.json"
    ]
baseContent = []
modContent = []
modFolders = []

def loadBaseContentAsJsonList():
    for file in baseContentList:
        baseContent.append({'file': file, 'json': json.load(open(os.path.join(dataPath, file), encoding='utf-8-sig'))})

def getModContentAsJson():
    for modDirectory in modFolders:
        for jsonFile in os.listdir(os.path.join(modPath, modDirectory)):
            if os.path.isfile(os.path.join(modPath, modDirectory, jsonFile)):
                modContent.append({"mod": modDirectory, "file": jsonFile, "json": json.load(open(os.path.join(modPath, modDirectory, jsonFile), encoding='utf-8-sig'))})

def getAlteredModJson():

    alteredContent = copy.deepcopy(baseContent)

    for alteredItem in alteredContent:
        for modContentItem in modContent:
            if modContentItem.get("file") == alteredItem.get("file"):
                if type(modContentItem.get("json")) != dict:
                    for item in modContentItem.get("json"):
                        alteredItem.get("json").append(item)
                else:
                    alteredItem.get("json").append(modContentItem.get("json"))

    return alteredContent

def replaceImagesWithModContent():
    for dir in modFolders:
        modContents = os.listdir(os.path.join(modPath, dir))
        if "images" in modContents:
            print(os.listdir(os.path.join(modPath, dir, "images")))
            for item in os.listdir(os.path.join(modPath, dir, "images")):
                copyfile(os.path.join(modPath, dir, "images", item), "./images/" + item)

def replaceBaseContentWithAlteredContent(alteredContent):

    for content in alteredContent:
        f = open(os.path.join(dataPath, content.get("file")), "w")
        f.write(json.dumps(content.get("json"), indent=4, sort_keys=True))
        f.close()

def restoreBaseContent():

    for content in baseContent:
        f = open(os.path.join(dataPath, content.get("file")), "w")
        f.write(json.dumps(content.get("json"), indent=4, sort_keys=True))
        f.close()

def getModDirectoryListings():
    if not os.path.exists(modPath):
        os.mkdir("./mods")
        pass
        
    for modDirectory in os.listdir(modPath):
        if os.path.isdir(os.path.join(modPath, modDirectory)):
            modFolders.append(modDirectory)

def get_pid(processName):
    #Iterate over the all the running process
    for proc in psutil.process_iter():
        try:
            # Check if process name contains the given name string.
            if processName.lower() in proc.name().lower():
                return True
        except (psutil.NoSuchProcess, psutil.AccessDenied, psutil.ZombieProcess):
            pass
    return False


def main():

    getModDirectoryListings()
    getModContentAsJson()
    loadBaseContentAsJsonList()
    replaceBaseContentWithAlteredContent(getAlteredModJson())

    if os.name == "posix":
        subprocess.run(["xdg-open", "steam://run/1022980"])
    elif os.name == "nt":
        subprocess.run(["%windir%\\explorer.exe", "steam://run/1022980"])

    processReady = False

    while processReady == False:
        if get_pid("Ostranauts.exe") != False:
            processReady = True
    
    while get_pid("Ostranauts.exe") != False:
        pass
    
    restoreBaseContent()

main()