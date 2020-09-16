import sys, subprocess, io, os, json

from PySide2.QtCore import (QCoreApplication, QDate, QDateTime, QMetaObject,
    QObject, QPoint, QRect, QSize, QTime, QUrl, Qt)
from PySide2.QtGui import (QBrush, QColor, QConicalGradient, QCursor, QFont,
    QFontDatabase, QIcon, QKeySequence, QLinearGradient, QPalette, QPainter,
    QPixmap, QRadialGradient)
from PySide2.QtWidgets import *

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        if not MainWindow.objectName():
            MainWindow.setObjectName(u"MainWindow")
        MainWindow.resize(348, 269)

        self.centralwidget = QWidget(MainWindow)
        self.centralwidget.setObjectName(u"centralwidget")
        self.listWidget = QListWidget(self.centralwidget)
        self.listWidget.setObjectName(u"listWidget")
        self.listWidget.setGeometry(QRect(10, 10, 321, 192))

        getModDirectoryListings()

        for mod in modFolders:
            listItem = QListWidgetItem(mod)
            self.listWidget.addItem(listItem)

        self.startButton = QPushButton(self.centralwidget)
        self.startButton.setObjectName(u"startButton")
        self.startButton.setGeometry(QRect(190, 210, 140, 23))
        self.startButton.clicked.connect(startButtonClicked)

        MainWindow.setCentralWidget(self.centralwidget)
        self.statusbar = QStatusBar(MainWindow)
        self.statusbar.setObjectName(u"statusbar")
        self.statusbar.setEnabled(True)
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)

        QMetaObject.connectSlotsByName(MainWindow)
    # setupUi

    def retranslateUi(self, MainWindow):
        MainWindow.setWindowTitle(QCoreApplication.translate("MainWindow", u"MainWindow", None))
        self.startButton.setText(QCoreApplication.translate("MainWindow", u"Start Ostranauts", None))
    # retranslateUi

dataPath = "./data/"
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

def startButtonClicked(self):
    if os.name == "posix":
        getModContentAsJson()
        loadBaseContentAsJsonList()
        alteredContent = getAlteredModJson()
        replaceBaseContentWithAlteredContent(alteredContent)
        subprocess.run(["xdg-open", "steam://run/1022980"])
        restoreBaseContent()
    elif os.name == "nt":
        getModContentAsJson()
        loadBaseContentAsJsonList()
        alteredContent = getAlteredModJson()
        replaceBaseContentWithAlteredContent(alteredContent)
        subprocess.run(["run", "steam://run/1022980"])
        restoreBaseContent()

def loadBaseContentAsJsonList():
    for file in baseContentList:
        print(file)
        baseContent.append({'file': file, 'json': json.load(open(os.path.join(dataPath, file), encoding='utf-8-sig'))})

def getModContentAsJson():
    for modDirectory in modFolders:
        for jsonFile in os.listdir(os.path.join(modPath, modDirectory)):
            modContent.append({"mod": modDirectory, "file": jsonFile, "json": json.load(open(os.path.join(modPath, modDirectory, jsonFile), encoding='utf-8-sig'))})

def getAlteredModJson():

    alteredContent = baseContent

    for alteredItem in alteredContent:
        for modContentItem in modContent:
            if modContentItem.get("file") == alteredItem.get("file"):
                alteredItem.get("json").append(modContentItem.get("json"))
    
    return alteredContent

def replaceBaseContentWithAlteredContent(alteredContent):

    for content in alteredContent:
        f = open(os.path.join(dataPath, content.get("file")), "w")
        f.write(json.dumps(content.get("json")))
        f.close()

def restoreBaseContent():

    for content in baseContent:
        f = open(os.path.join(dataPath, content.get("file")), "w")
        f.write(json.dumps(content.get("json")))
        f.close()

def getModDirectoryListings():
    if not os.path.exists(modPath):
        os.mkdir("./mods")
        pass
        
    for modDirectory in os.listdir(modPath):
        if os.path.isdir(os.path.join(modPath, modDirectory)):
            modFolders.append(modDirectory)

app = QApplication(sys.argv)
mainWindow = QMainWindow()

window = Ui_MainWindow()
window.setupUi(mainWindow)

mainWindow.show()

app.exec_()

restoreBaseContent()