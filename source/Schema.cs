using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace ostranauts_modding
{
    public class Schema
    {
        public string m_directory { get; set; }

        public void Initialize(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            m_directory = directory;

            ad = LoadJson<Ad>("ads.json");
            crewSkin = LoadJson<CrewSkin>("crewskins.json");
            loot = LoadJson<Loot>("loot.json");
            audioEmitter = LoadJson<AudioEmitter>("audioemitters.json");
            gasRespire = LoadJson<GasRespire>("gasrespires.json");
            music = LoadJson<Music>("music.json");
            career = LoadJson<Career>("careers.json");
            GUIPropMap = LoadJson<GUIPropMap>("guipropmaps.json");
            personSpec = LoadJson<PersonSpec>("personspecs.json");
            color = LoadJson<Color>("colors.json");
            headline = LoadJson<Headline>("headlines.json");
            plot = LoadJson<Plot>("plots.json");
            computerEntry = LoadJson<ComputerEntry>("computerentries.json");
            homeworld = LoadJson<Homeworld>("homeworlds.json");
            powerInfo = LoadJson<PowerInfo>("powerinfos.json");
            condition = LoadJson<Condition>("conditions.json");
            installable = LoadJson<Installable>("installables.json");
            role = LoadJson<Role>("roles.json");
            conditionOverlay = LoadJson<ConditionOverlay>("cooverlays.json");
            interaction = LoadJson<Interaction>("interactions.json");
            interaction2 = LoadJson<Interaction>("interactions2.json");
            slot = LoadJson<Slot>("slots.json");
            conditionOwner = LoadJson<ConditionOwner>("condowners.json");
            interactionSocialCombat = LoadJson<InteractionSocialCombat>("interactionsSocialCombat.json");
            task = LoadJson<Task>("tasks.json");
            conditionRule = LoadJson<ConditionRule>("condrules.json");
            item = LoadJson<Item>("items.json");
            ticker = LoadJson<Ticker>("tickers.json");
            conditionSimple = LoadJson<ConditionSimple>("conditions_simple.json");
            lifeEvent = LoadJson<LifeEvent>("lifeevents.json");
            traitScore = LoadJson<TraitScore>("traitscores.json");
            conditionTrigger = LoadJson<ConditionTrigger>("condtrigs.json");
            light = LoadJson<Light>("lights.json");
        }

        public List<T> LoadJson<T>(string file)
        {
            if(File.Exists(Path.Join(m_directory, file)))
            {
                return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Path.Join(m_directory, file)));
            }
            else
            {
                return null;
            }
        }

        public void WriteJson()
        {
            WriteJsonToFile(ad, "ads.json");
            WriteJsonToFile(crewSkin, "crewskins.json");
            WriteJsonToFile(loot, "loot.json");
            WriteJsonToFile(audioEmitter, "audioemitters.json");
            WriteJsonToFile(gasRespire, "gasrespires.json");
            WriteJsonToFile(music, "music.json");
            WriteJsonToFile(career, "careers.json");
            WriteJsonToFile(GUIPropMap, "guipropmaps.json");
            WriteJsonToFile(personSpec, "personspecs.json");
            WriteJsonToFile(color, "colors.json");
            WriteJsonToFile(headline, "headlines.json");
            WriteJsonToFile(plot, "plots.json");
            WriteJsonToFile(computerEntry, "computerentries.json");
            WriteJsonToFile(homeworld, "homeworlds.json");
            WriteJsonToFile(powerInfo, "powerinfos.json");
            WriteJsonToFile(condition, "conditions.json");
            WriteJsonToFile(installable, "installables.json");
            WriteJsonToFile(role, "roles.json");
            WriteJsonToFile(conditionOverlay, "cooverlays.json");
            WriteJsonToFile(interaction, "interactions.json");
            WriteJsonToFile(interaction2, "interactions2.json");
            WriteJsonToFile(slot, "slots.json");
            WriteJsonToFile(conditionOwner, "condowners.json");
            WriteJsonToFile(interactionSocialCombat, "interactionsSocialCombat.json");
            WriteJsonToFile(task, "tasks.json");
            WriteJsonToFile(conditionRule, "condrules.json");
            WriteJsonToFile(item, "items.json");
            WriteJsonToFile(ticker, "tickers.json");
            WriteJsonToFile(conditionSimple, "conditions_simple.json");
            WriteJsonToFile(lifeEvent, "lifeevents.json");
            WriteJsonToFile(traitScore, "traitscores.json");
            WriteJsonToFile(conditionTrigger, "condtrigs.json");
            WriteJsonToFile(light, "lights.json");
        }

        public void WriteJsonToFile(object jsonObject, string file)
        {
            File.WriteAllText(Path.Join("data", file), JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            }));
        }

        public void ReplaceValues(Schema schema)
        {
            if(ad != null && schema.ad!= null)
            {
                ad = ad.ConvertAll<Ad>(i =>
                {
                    var sv = schema.ad.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(crewSkin != null && schema.crewSkin!= null)
            {
                crewSkin = crewSkin.ConvertAll<CrewSkin>(i =>
                {
                    var sv = schema.crewSkin.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(loot != null && schema.loot!= null)
            {
                loot = loot.ConvertAll<Loot>(i =>
                {
                    var sv = schema.loot.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                    {
                        sv.aCOs.ToList().ForEach(k => i.aCOs.Add(k));
                        return i;
                    }
                    else
                        return i;
                });
            }

            if(audioEmitter != null && schema.audioEmitter!= null)
            {
                audioEmitter = audioEmitter.ConvertAll<AudioEmitter>(i =>
                {
                    var sv = schema.audioEmitter.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(gasRespire != null && schema.gasRespire!= null)
            {
                gasRespire = gasRespire.ConvertAll<GasRespire>(i =>
                {
                    var sv = schema.gasRespire.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(music != null && schema.music!= null)
            {
                music = music.ConvertAll<Music>(i =>
                {
                    var sv = schema.music.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(career != null && schema.career!= null)
            {
                career = career.ConvertAll<Career>(i =>
                {
                    var sv = schema.career.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(GUIPropMap != null && schema.GUIPropMap!= null)
            {
                GUIPropMap = GUIPropMap.ConvertAll<GUIPropMap>(i =>
                {
                    var sv = schema.GUIPropMap.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(personSpec != null && schema.personSpec!= null)
            {
                personSpec = personSpec.ConvertAll<PersonSpec>(i =>
                {
                    var sv = schema.personSpec.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(color != null && schema.color!= null)
            {
                color = color.ConvertAll<Color>(i =>
                {
                    var sv = schema.color.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(headline != null && schema.headline!= null)
            {
                headline = headline.ConvertAll<Headline>(i =>
                {
                    var sv = schema.headline.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(plot != null && schema.plot!= null)
            {
                plot = plot.ConvertAll<Plot>(i =>
                {
                    var sv = schema.plot.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(computerEntry != null && schema.computerEntry!= null)
            {
                computerEntry = computerEntry.ConvertAll<ComputerEntry>(i =>
                {
                    var sv = schema.computerEntry.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(homeworld != null && schema.homeworld!= null)
            {
                homeworld = homeworld.ConvertAll<Homeworld>(i =>
                {
                    var sv = schema.homeworld.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(powerInfo != null && schema.powerInfo!= null)
            {
                powerInfo = powerInfo.ConvertAll<PowerInfo>(i =>
                {
                    var sv = schema.powerInfo.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(condition != null && schema.condition!= null)
            {
                condition = condition.ConvertAll<Condition>(i =>
                {
                    var sv = schema.condition.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(installable != null && schema.installable!= null)
            {
                installable = installable.ConvertAll<Installable>(i =>
                {
                    var sv = schema.installable.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(role != null && schema.role!= null)
            {
                role = role.ConvertAll<Role>(i =>
                {
                    var sv = schema.role.Where(j => j.strBaseName == i.strBaseName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(conditionOverlay != null && schema.conditionOverlay!= null)
            {
                conditionOverlay = conditionOverlay.ConvertAll<ConditionOverlay>(i =>
                {
                    var sv = schema.conditionOverlay.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(interaction != null && schema.interaction!= null)
            {
                interaction = interaction.ConvertAll<Interaction>(i =>
                {
                    var sv = schema.interaction.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(interaction2 != null && schema.interaction2!= null)
            {
                interaction2 = interaction2.ConvertAll<Interaction>(i =>
                {
                    var sv = schema.interaction2.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(slot != null && schema.slot!= null)
            {
                slot = slot.ConvertAll<Slot>(i =>
                {
                    var sv = schema.slot.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(conditionOwner != null && schema.conditionOwner!= null)
            {
                conditionOwner = conditionOwner.ConvertAll<ConditionOwner>(i =>
                {
                    var sv = schema.conditionOwner.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(interactionSocialCombat != null && schema.interactionSocialCombat!= null)
            {
                interactionSocialCombat = interactionSocialCombat.ConvertAll<InteractionSocialCombat>(i =>
                {
                    var sv = schema.interactionSocialCombat.Where(j => j.internalName == i.internalName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(task != null && schema.task!= null)
            {
                task = task.ConvertAll<Task>(i =>
                {
                    var sv = schema.task.Where(j => j.strBaseName == i.strBaseName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(conditionRule != null && schema.conditionRule!= null)
            {
                conditionRule = conditionRule.ConvertAll<ConditionRule>(i =>
                {
                    var sv = schema.conditionRule.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(item != null && schema.item!= null)
            {
                item = item.ConvertAll<Item>(i =>
                {
                    var sv = schema.item.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(ticker != null && schema.ticker!= null)
            {
                ticker = ticker.ConvertAll<Ticker>(i =>
                {
                    var sv = schema.ticker.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(conditionSimple != null && schema.conditionSimple!= null)
            {
                conditionSimple = conditionSimple.ConvertAll<ConditionSimple>(i =>
                {
                    var sv = schema.conditionSimple.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                    {
                        sv.aValues.ToList().ForEach(k => i.aValues.Add(k));
                        return i;
                    }
                    else
                        return i;
                });
            }

            if(lifeEvent != null && schema.lifeEvent!= null)
            {
                lifeEvent = lifeEvent.ConvertAll<LifeEvent>(i =>
                {
                    var sv = schema.lifeEvent.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(traitScore != null && schema.traitScore!= null)
            {
                traitScore = traitScore.ConvertAll<TraitScore>(i =>
                {
                    var sv = schema.traitScore.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(conditionTrigger != null && schema.conditionTrigger!= null)
            {
                conditionTrigger = conditionTrigger.ConvertAll<ConditionTrigger>(i =>
                {
                    var sv = schema.conditionTrigger.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }

            if(light != null && schema.light!= null)
            {
                light = light.ConvertAll<Light>(i =>
                {
                    var sv = schema.light.Where(j => j.strName == i.strName).SingleOrDefault();
                    if(sv != null)
                        return sv;
                    else
                        return i;
                });
            }
        }

        public void AppendValues(Schema schema)
        {
            if(ad != null && schema.ad != null)
            {
                schema.ad.ForEach(i =>
                {
                    var match = ad.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        ad = ad.Append(i).ToList();
                    }
                });
            }

            if(crewSkin != null && schema.crewSkin != null)
            {
                schema.crewSkin.ForEach(i =>
                {
                    var match = crewSkin.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        crewSkin = crewSkin.Append(i).ToList();
                    }
                });
            }

            if(loot != null && schema.loot != null)
            {
                schema.loot.ForEach(i =>
                {
                    var match = loot.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        loot = loot.Append(i).ToList();
                    }
                });
            }

            if(audioEmitter != null && schema.audioEmitter != null)
            {
                schema.audioEmitter.ForEach(i =>
                {
                    var match = audioEmitter.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        audioEmitter = audioEmitter.Append(i).ToList();
                    }
                });
            }

            if(gasRespire != null && schema.gasRespire != null)
            {
                schema.gasRespire.ForEach(i =>
                {
                    var match = gasRespire.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        gasRespire = gasRespire.Append(i).ToList();
                    }
                });
            }

            if(music != null && schema.music != null)
            {
                schema.music.ForEach(i =>
                {
                    var match = music.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        music = music.Append(i).ToList();
                    }
                });
            }

            if(career != null && schema.career != null)
            {
                schema.career.ForEach(i =>
                {
                    var match = career.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        career = career.Append(i).ToList();
                    }
                });
            }

            if(GUIPropMap != null && schema.GUIPropMap != null)
            {
                schema.GUIPropMap.ForEach(i =>
                {
                    var match = GUIPropMap.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        GUIPropMap = GUIPropMap.Append(i).ToList();
                    }
                });
            }

            if(personSpec != null && schema.personSpec != null)
            {
                schema.personSpec.ForEach(i =>
                {
                    var match = personSpec.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        personSpec = personSpec.Append(i).ToList();
                    }
                });
            }

            if(color != null && schema.color != null)
            {
                schema.color.ForEach(i =>
                {
                    var match = color.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        color = color.Append(i).ToList();
                    }
                });
            }

            if(headline != null && schema.headline != null)
            {
                schema.headline.ForEach(i =>
                {
                    var match = headline.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        headline = headline.Append(i).ToList();
                    }
                });
            }

            if(plot != null && schema.plot != null)
            {
                schema.plot.ForEach(i =>
                {
                    var match = plot.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        plot = plot.Append(i).ToList();
                    }
                });
            }

            if(computerEntry != null && schema.computerEntry != null)
            {
                schema.computerEntry.ForEach(i =>
                {
                    var match = computerEntry.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        computerEntry = computerEntry.Append(i).ToList();
                    }
                });
            }

            if(homeworld != null && schema.homeworld != null)
            {
                schema.homeworld.ForEach(i =>
                {
                    var match = homeworld.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        homeworld = homeworld.Append(i).ToList();
                    }
                });
            }

            if(powerInfo != null && schema.powerInfo != null)
            {
                schema.powerInfo.ForEach(i =>
                {
                    var match = powerInfo.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        powerInfo = powerInfo.Append(i).ToList();
                    }
                });
            }

            if(condition != null && schema.condition != null)
            {
                schema.condition.ForEach(i =>
                {
                    var match = condition.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        condition = condition.Append(i).ToList();
                    }
                });
            }

            if(installable != null && schema.installable != null)
            {
                schema.installable.ForEach(i =>
                {
                    var match = installable.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        installable = installable.Append(i).ToList();
                    }
                });
            }

            if(role != null && schema.role != null)
            {
                schema.role.ForEach(i =>
                {
                    var match = role.Where(j => j.strBaseName == i.strBaseName).Any();
                    if (!match)
                    {
                        role = role.Append(i).ToList();
                    }
                });
            }

            if(conditionOverlay != null && schema.conditionOverlay != null)
            {
                schema.conditionOverlay.ForEach(i =>
                {
                    var match = conditionOverlay.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        conditionOverlay = conditionOverlay.Append(i).ToList();
                    }
                });
            }

            if(interaction != null && schema.interaction != null)
            {
                schema.interaction.ForEach(i =>
                {
                    var match = interaction.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        interaction = interaction.Append(i).ToList();
                    }
                });
            }

            if(interaction2 != null && schema.interaction2 != null)
            {
                schema.interaction2.ForEach(i =>
                {
                    var match = interaction2.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        interaction2 = interaction2.Append(i).ToList();
                    }
                });
            }

            if(slot != null && schema.slot != null)
            {
                schema.slot.ForEach(i =>
                {
                    var match = slot.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        slot = slot.Append(i).ToList();
                    }
                });
            }

            if(conditionOwner != null && schema.conditionOwner != null)
            {
                schema.conditionOwner.ForEach(i =>
                {
                    var match = conditionOwner.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        conditionOwner = conditionOwner.Append(i).ToList();
                    }
                });
            }

            if(interactionSocialCombat != null && schema.interactionSocialCombat != null)
            {
                schema.interactionSocialCombat.ForEach(i =>
                {
                    var match = interactionSocialCombat.Where(j => j.internalName == i.internalName).Any();
                    if (!match)
                    {
                        interactionSocialCombat = interactionSocialCombat.Append(i).ToList();
                    }
                });
            }

            if(task != null && schema.task != null)
            {
                schema.task.ForEach(i =>
                {
                    var match = task.Where(j => j.strBaseName == i.strBaseName).Any();
                    if (!match)
                    {
                        task = task.Append(i).ToList();
                    }
                });
            }

            if(conditionRule != null && schema.conditionRule != null)
            {
                schema.conditionRule.ForEach(i =>
                {
                    var match = conditionRule.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        conditionRule = conditionRule.Append(i).ToList();
                    }
                });
            }

            if(item != null && schema.item != null)
            {
                schema.item.ForEach(i =>
                {
                    var match = item.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        item = item.Append(i).ToList();
                    }
                });
            }

            if(ticker != null && schema.ticker != null)
            {
                schema.ticker.ForEach(i =>
                {
                    var match = ticker.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        ticker = ticker.Append(i).ToList();
                    }
                });
            }

            // if(conditionSimple != null && schema.conditionSimple != null)
            // {
            //     schema.conditionSimple.ForEach(i =>
            //     {
            //         var match = conditionSimple.Where(j => j.strName == i.strName).Any();
            //         if (!match)
            //         {
            //             conditionSimple = conditionSimple..Append(i).ToList();
            //         }
            //     });
            // }

            if(lifeEvent != null && schema.lifeEvent != null)
            {
                schema.lifeEvent.ForEach(i =>
                {
                    var match = lifeEvent.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        lifeEvent = lifeEvent.Append(i).ToList();
                    }
                });
            }

            if(traitScore != null && schema.traitScore != null)
            {
                schema.traitScore.ForEach(i =>
                {
                    var match = traitScore.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        traitScore = traitScore.Append(i).ToList();
                    }
                });
            }

            if(conditionTrigger != null && schema.conditionTrigger != null)
            {
                schema.conditionTrigger.ForEach(i =>
                {
                    var match = conditionTrigger.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        conditionTrigger = conditionTrigger.Append(i).ToList();
                    }
                });
            }

            if(light != null && schema.light != null)
            {
                schema.light.ForEach(i =>
                {
                    var match = light.Where(j => j.strName == i.strName).Any();
                    if (!match)
                    {
                        light = light.Append(i).ToList();
                    }
                });
            }

        }

        public List<Ad> ad { get; set; }
        public List<CrewSkin> crewSkin { get; set; }
        public List<Loot> loot { get; set; }
        public List<AudioEmitter> audioEmitter { get; set; }
        public List<GasRespire> gasRespire { get; set; }
        public List<Music> music { get; set; }
        public List<Career> career { get; set; }
        public List<GUIPropMap> GUIPropMap { get; set; }
        public List<PersonSpec> personSpec { get; set; }
        public List<Color> color { get; set; }
        public List<Headline> headline { get; set; }
        public List<Plot> plot { get; set; }
        public List<ComputerEntry> computerEntry { get; set; }
        public List<Homeworld> homeworld { get; set; }
        public List<PowerInfo> powerInfo { get; set; }
        public List<Condition> condition { get; set; }
        public List<Installable> installable { get; set; }
        public List<Role> role { get; set; }
        public List<ConditionOverlay> conditionOverlay { get; set; }
        public List<Interaction> interaction { get; set; }
        public List<Interaction> interaction2 { get; set; }
        public List<Ship> ship { get; set; }
        public List<Slot> slot { get; set; }
        public List<ConditionOwner> conditionOwner { get; set; }
        public List<InteractionSocialCombat> interactionSocialCombat { get; set; }
        public List<Task> task { get; set; }
        public List<ConditionRule> conditionRule { get; set; }
        public List<Item> item { get; set; }
        public List<Ticker> ticker { get; set; }
        public List<ConditionSimple> conditionSimple { get; set; }
        public List<LifeEvent> lifeEvent { get; set; }
        public List<TraitScore> traitScore { get; set; }
        public List<ConditionTrigger> conditionTrigger { get; set; }
        public List<Light> light { get; set; }

    }

    public static class Extensions
    {
        public static object GetPropValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}