using System;
using System.Linq;
using AzurLaneClasses;

namespace AzurLaneAPI.Seeders
{
    public class CampaignSeeder
    {
        
        public static void Seed()
        {
            AzurLaneDbContext ctx = new AzurLaneDbContext();
            
            if (ctx.CampaignLevels.ToArray().Length == 0)
            {
                #region Chapter 1

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 1, 
                    Level = 0, 
                    EN_Name = "Tora! Tora! Tora!",
                    CN_Name = "Tora! Tora! Tora!",
                    JP_Name = "トラ！トラ！トラ！"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 1, 
                    Level = 1, 
                    EN_Name = "Offshore Exercises",
                    CN_Name = "近海演习",
                    JP_Name = "近海演習"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 1, 
                    Level = 2, 
                    EN_Name = "Tora! Tora! Tora!",
                    CN_Name = "虎！虎！虎！",
                    JP_Name = "トラトラトラ "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 1, 
                    Level = 3, 
                    EN_Name = "The Harbor Clash",
                    CN_Name = "燃烧的军港",
                    JP_Name = "軍港燃ゆ"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 1, 
                    Level = 4, 
                    EN_Name = "Sakura Fleet",
                    CN_Name = "来自东方的舰队",
                    JP_Name = "東より来る敵"
                });

                #endregion

                #region Chapter 2

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 2, 
                    Level = 0, 
                    EN_Name = "Battle of Coral Sea",
                    CN_Name = "珊瑚海首秀",
                    JP_Name = "初陣!珊瑚海"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 2, 
                    Level = 1, 
                    EN_Name = "Fuerteventura",
                    CN_Name = "支援图拉岛",
                    JP_Name = "ツラギ支援"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 2, 
                    Level = 2, 
                    EN_Name = "Dark Clouds",
                    CN_Name = "乌云蔽日",
                    JP_Name = "太陽を隠す暗雲"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 2, 
                    Level = 3, 
                    EN_Name = "Coral Sea Fortune",
                    CN_Name = "珊瑚海的首秀",
                    JP_Name = "初陣!珊瑚海"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 2, 
                    Level = 4, 
                    EN_Name = "Rescuing Yorktown",
                    CN_Name = "救援约克城",
                    JP_Name = "空母対空母"
                });

                #endregion

                #region Chapter 3

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 3, 
                    Level = 0, 
                    EN_Name = "Midway Showdown",
                    CN_Name = "决战中途岛",
                    JP_Name = "決戦"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 3, 
                    Level = 1, 
                    EN_Name = "Midway Showdown!",
                    CN_Name = "决战中途岛！",
                    JP_Name = "決戦へ"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 3, 
                    Level = 2, 
                    EN_Name = "The Five Minutes",
                    CN_Name = "命运的五分钟",
                    JP_Name = "運命の5分間"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 3, 
                    Level = 3, 
                    EN_Name = "The Last Stand",
                    CN_Name = "背水一战",
                    JP_Name = "背水の戦い"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 3, 
                    Level = 4, 
                    EN_Name = "Counterattack!",
                    CN_Name = "最后的反击",
                    JP_Name = "最後の反撃"
                });

                #endregion

                #region Chapter 4

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 4, 
                    Level = 0, 
                    EN_Name = "Solomon's Nightmare Pt. 1",
                    CN_Name = "所罗门的噩梦上 ",
                    JP_Name = "ソロモン海にて·上 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 4, 
                    Level = 1, 
                    EN_Name = "Midnight Fright",
                    CN_Name = "午夜惊魂",
                    JP_Name = "宵闇の死神 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 4, 
                    Level = 2, 
                    EN_Name = "Scarlet Dawn",
                    CN_Name = "血色黎明",
                    JP_Name = "血染めの暁 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 4, 
                    Level = 3, 
                    EN_Name = "Solomon Skirmish",
                    CN_Name = "东所罗门遭遇战",
                    JP_Name = "東ソロモンにて "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 4, 
                    Level = 4, 
                    EN_Name = "War of Vengeance",
                    CN_Name = "复仇之战",
                    JP_Name = "仇討ちの戦い "
                });

                #endregion

                #region Chapter 5

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 5, 
                    Level = 0, 
                    EN_Name = "Solomon's Nightmare Pt. 2 ",
                    CN_Name = "所罗门的噩梦中 ",
                    JP_Name = "ソロモン海にて·中 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 5, 
                    Level = 1, 
                    EN_Name = "Interception",
                    CN_Name = "物资拦截战 ",
                    JP_Name = "輸送阻止作戦"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 5, 
                    Level = 2, 
                    EN_Name = "Santa Cruz Skies ",
                    CN_Name = "圣克鲁斯的天空",
                    JP_Name = "聖十字の空 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 5, 
                    Level = 3, 
                    EN_Name = "Hornet's Fall ",
                    CN_Name = "大黄蜂的陨落",
                    JP_Name = "ホーネット墜つ "
                });
                
                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 5, 
                    Level = 4, 
                    EN_Name = "Evacuation ",
                    CN_Name = "撤离战区",
                    JP_Name = "戦域から脱出 "
                });

                #endregion

                #region  Chapter 6

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 6, 
                    Level = 0, 
                    EN_Name = "Solomon's Nightmare Pt. 3 ",
                    CN_Name = "所罗门的噩梦下 ",
                    JP_Name = "ソロモン海にて·下 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 6, 
                    Level = 1, 
                    EN_Name = "Darkness Elites ",
                    CN_Name = "夜战精英",
                    JP_Name = "夜戦対決"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 6, 
                    Level = 2, 
                    EN_Name = "Counterattack ",
                    CN_Name = "反攻",
                    JP_Name = "全面反撃 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 6, 
                    Level = 3, 
                    EN_Name = "Cannon Showdown ",
                    CN_Name = "巨炮最后的对决",
                    JP_Name = "巨砲最後の戦い "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 6, 
                    Level = 4, 
                    EN_Name = "Solomon's Tears ",
                    CN_Name = "所罗门的噩梦",
                    JP_Name = "ソロモンの悪夢 "
                });

                #endregion

                #region Chapter 7

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 7, 
                    Level = 0, 
                    EN_Name = "Night of Chaos ",
                    CN_Name = "混沌之夜",
                    JP_Name = "混沌の夜 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 7, 
                    Level = 1, 
                    EN_Name = "The Ambush ",
                    CN_Name = "增援拦截",
                    JP_Name = "増援阻止 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 7, 
                    Level = 2, 
                    EN_Name = "Close Combat ",
                    CN_Name = "短兵相接",
                    JP_Name = "乱戦"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 7, 
                    Level = 3, 
                    EN_Name = "Unprepared ",
                    CN_Name = "措手不及",
                    JP_Name = "奇襲"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 7, 
                    Level = 4, 
                    EN_Name = "Unforeseen Chaos ",
                    CN_Name = "预料外的混乱",
                    JP_Name = "予想外の混乱 "
                });

                #endregion

                #region Chapter 8

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 8, 
                    Level = 0, 
                    EN_Name = "Battle Komandorski ",
                    CN_Name = "科曼多尔海战役",
                    JP_Name = "極北の海戦 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 8, 
                    Level = 1, 
                    EN_Name = "Cold Wind ",
                    CN_Name = "寒风",
                    JP_Name = "極北の風 "
                });
                
                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 8, 
                    Level = 2, 
                    EN_Name = "Arctic Daybreak ",
                    CN_Name = "北极圈的拂晓",
                    JP_Name = "北極圏の朝霧 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 8, 
                    Level = 3, 
                    EN_Name = "Arctic Fury ",
                    CN_Name = "冰海怒涛",
                    JP_Name = "氷の荒波 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 8, 
                    Level = 4, 
                    EN_Name = "Old Battlefield ",
                    CN_Name = "被遗忘的战场",
                    JP_Name = "忘れられし戦場 "
                });

                #endregion

                #region Chapter 9

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 9, 
                    Level = 0, 
                    EN_Name = "Battle of Kula Gulf ",
                    CN_Name = "库拉湾海战 ",
                    JP_Name = "クラ湾海戦 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 9, 
                    Level = 1, 
                    EN_Name = "The Night is Dark ",
                    CN_Name = "不祥之夜",
                    JP_Name = "凶兆の夜 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 9, 
                    Level = 2, 
                    EN_Name = "Torpedo Rush ",
                    CN_Name = "拦截作战",
                    JP_Name = "迎撃作戦 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 9, 
                    Level = 3, 
                    EN_Name = "Light in the Dark ",
                    CN_Name = "黑夜中的光芒",
                    JP_Name = "暗闇の光 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 9, 
                    Level = 4, 
                    EN_Name = "Helena ",
                    CN_Name = "海伦娜",
                    JP_Name = "ヘレナ"
                });

                #endregion

                #region Chapter 10

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 10, 
                    Level = 0, 
                    EN_Name = "Battle of Kolombangara ",
                    CN_Name = "科隆班加拉岛夜战",
                    JP_Name = "コロンバンガラ島沖海戦 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 10, 
                    Level = 1, 
                    EN_Name = "Once More, Sortie Again! ",
                    CN_Name = "再次出击，再次！ ",
                    JP_Name = "二度目の出撃 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 10, 
                    Level = 2, 
                    EN_Name = "Preemptive Strike ",
                    CN_Name = "先发制人 ",
                    JP_Name = "先制攻撃! "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 10, 
                    Level = 3, 
                    EN_Name = "Press the Attack ",
                    CN_Name = "乘胜追击",
                    JP_Name = "勝利に乗じて "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 10, 
                    Level = 4, 
                    EN_Name = "Counterattack ",
                    CN_Name = "回马枪",
                    JP_Name = "釣り野伏 "
                });

                #endregion

                #region Chapter 11

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 11, 
                    Level = 0, 
                    EN_Name = "Empress Augusta Bay ",
                    CN_Name = "奥古斯塔皇后湾海战 ",
                    JP_Name = "エンプレスオーガスタ"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 11, 
                    Level = 1, 
                    EN_Name = "Landing Operation ",
                    CN_Name = "拂晓登陆！ ",
                    JP_Name = "夜明けの上陸作戦 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 11, 
                    Level = 2, 
                    EN_Name = "Stormy Night ",
                    CN_Name = "暴风雨之夜 ",
                    JP_Name = "嵐の夜 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 11, 
                    Level = 3, 
                    EN_Name = "Knights of the Sea ",
                    CN_Name = "所罗门四骑士 ",
                    JP_Name = "海上騎士団"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 11, 
                    Level = 4, 
                    EN_Name = "Part the Night ",
                    CN_Name = "撕裂黑夜！ ",
                    JP_Name = "夜を切り裂いて "
                });

                #endregion

                #region Chapter 12

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 12, 
                    Level = 0, 
                    EN_Name = "Mariana's Turmoil Pt. 1 ",
                    CN_Name = "马里亚纳风云上 ",
                    JP_Name = "風雲マリアナ・上 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 12, 
                    Level = 1, 
                    EN_Name = "Information Warfare ",
                    CN_Name = "先声夺人 ",
                    JP_Name = "情報戦の戦果 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 12, 
                    Level = 2, 
                    EN_Name = "Ambush ",
                    CN_Name = "鲁莽的后果 ",
                    JP_Name = "奇襲攻撃 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 12, 
                    Level = 3, 
                    EN_Name = "Carrier Showdown ",
                    CN_Name = "空中对决 ",
                    JP_Name = "空母対決"
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 12, 
                    Level = 4, 
                    EN_Name = "Task Force ",
                    CN_Name = "TF58，翱翔于天际 ",
                    JP_Name = "タスクフォース "
                });

                #endregion

                #region Chapter 13

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 13, 
                    Level = 0, 
                    EN_Name = "Mariana's Turmoil Pt. 2 ",
                    CN_Name = "马里亚纳风云下 ",
                    JP_Name = "風雲マリアナ・下 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 13, 
                    Level = 1, 
                    EN_Name = "The Skies Above ",
                    CN_Name = "激战的长空 ",
                    JP_Name = "戦いの空 "
                });


                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 13, 
                    Level = 2, 
                    EN_Name = "The Eternal Flute ",
                    CN_Name = "羽栖之鹤 ",
                    JP_Name = "悠遠の笛 "
                });


                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 13, 
                    Level = 3, 
                    EN_Name = "Wings of Inspiration ",
                    CN_Name = "奋起之鹤 ",
                    JP_Name = "奮起の双翼 "
                });

                ctx.CampaignLevels.Add(new CampaignLevel { 
                    Id = Guid.NewGuid(), 
                    Chapter = 13, 
                    Level = 4, 
                    EN_Name = "The Dancing Phoenix ",
                    CN_Name = "起舞之凤 ",
                    JP_Name = "舞い降りる鳳 "
                });

                #endregion

                #region Saving

                ctx.SaveChanges();

                #endregion
            }
        }
    }
}