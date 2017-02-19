using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace BattleGrounds
{
    public class Analysis
    {

        private const string API_KEY = "1779c3313e4d90d66ddfbb3795cae3bc";
        //string input = "Skills and abilities Batman has no inherent super powers, he relies on his own scientific knowledge skills and athletic prowess in the stories. Batman is regarded as one of the world's greatest detective if not the world's greatest crime solvers. That man has been repeatedly described as having genius level intellect. One of the greatest martial artists in the DC universe and having peak human physical conditioning is traveled the world, acquiring the skills needed to 8. His knowledge and expertise in almost every discipline known to man is nearly unparalleled by any other character in the universe. Badman's inexhaustible well allows him to access advanced technology as a profession scientists use able to use in modify those technologies to his advantage. Describes Superman as the most dangerous man on Earth able to defeat a team of superpowered extraterrestrials by himself in order to rescue his in prison teammates. In the first storyline, Superman also considers Batman to be one of the most brilliant minds on the planet. Batman has the ability to function under great physical pain and will stand mind control. He is a master of disguise multilingual, an expert in espionage off and gathering information under different identity's. Fatman's Karate Judo and Jiu Jitsu training has made him a Master Master of stuff and escaped allowing too much allow him to appear and disappear at will break free.";
        public string Input
        {
            get;
            set;
        }
        // string input = "Hello, my, my, name is to to to be be be the the the hello.";

        List<string> blackList;
        List<string> profanityList;

        public Analysis()
        {
            //var dic = new Dictionary<string, int>();
            blackList = new List<string> { " the ", " to ", " be ", " a ", " about ", " above ", " after ", " again ", " against ", " all ", " am ", " an ", " and ", " any ", " aren't ", " as ", " at ", " be ", " because ", " been ", " before ", " being ", " below ", " between ", " both ", " but ", " by ", " couldn't ", " didn't ", " doesn't ", " doing ", " don't ", " down ", " during ", " each ", " few ", " for ", " from ", " further ", " hadn't ", " hasn't ", " haven't ", " he ", " he'd ", " he'll ", " he's ", " her ", " here's ", " hers ", " herself ", " him ", " himself ", " his ", " how ", " how's ", " i ", " i'd ", " i'll ", " i'm ", " i've ", " if ", " in ", " into ", " is ", " isn't ", " it ", " it's ", " its ", " itself ", " let's ", " me ", " more ", " most ", " mustn't ", " my ", " myself ", " no ", " nor ", " not ", " of ", " off ", " on ", " or ", " other ", " ought ", " our ", " ours ", " ourselves ", " out ", " over ", " own ", " shan't ", " she ", " she'd ", " she'll ", " shouldn't ", " such ", " than ", " that ", " that's ", " the ", " their ", " theirs ", " then ", " there's ", " they ", " they'd ", " they'll ", " they're ", " they've ", " those ", " through ", " to ", " under ", " until ", " up ", " wasn't ", " we ", " we'd ", " we'll ", " we're ", " we've ", " were ", " weren't ", " what ", " what's ", " when's ", " where ", " where's ", " which ", " while ", " who ", " who's ", " whom ", " why ", " why's ", " with ", " won't ", " would ", " wouldn't ", " you ", " you'd ", " you'll ", " you're ", " you've ", " your ", " yours ", " yourself ", " yourselves " };
            profanityList = new List<string> { " fuck ", " shit ", " hell ", " ass ", " bitch ", " fucker ", " faggot ", " dick ", " motherfucker ", " bitchass ", " shitter ", " fucking ", " shitting " };

        }


        // ============
        // Function to get the TOTAL word count for every single word used in the speech/text
        public Dictionary<string, int> WordCount()
        {
            // lowercase all text to make sure they Sample and sample are not diff words
            Input = Input.ToLower();

            // parsing through text
            var words = Input.Split(new[] { ' ', ',', '!', '?', ':', ';', '.', '\n', '\"', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var groups = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
            rankNumber(ref groups);


            return groups;
        }


        // ============
        // Function to get the words that you SHOULD and COULD replace in your vocabulary.
        public Dictionary<string, int> ReplaceWords()
        {
            // lowercase all text to make sure they Sample and sample are not diff words
            Input = Input.ToLower();

            // Get rid of all the blacklist words
            StringBuilder newInput = new StringBuilder(Input);
            foreach (string word in blackList)
            {
                newInput.Replace(word, " ");
            }
            foreach (string profanity in profanityList)
                newInput.Replace(profanity, " flower ");

            Input = newInput.ToString();

            // parsing through text also using a blacklist
            List<string> delims = new List<string> { " ", ",", "!", "?", ":", ";", ".", " ", "\n", "\"", "-", "--" };
            //delims.AddRange(blackList);

            string[] newDelim = delims.ToArray();

            // parse through text with added black list items
            var words = Input.Split(newDelim, StringSplitOptions.RemoveEmptyEntries);
            var groups = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
            rankNumber(ref groups);

            return groups;



        }

        // ============
        // Functino to rank the words based on the value which is the count of how many times its been used.
        public void rankNumber(ref Dictionary<string, int> input)
        {

            IOrderedEnumerable<KeyValuePair<string, int>> query = input.OrderByDescending(r => r.Value);
            input = query.ToDictionary<KeyValuePair<string, int>, string, int>(pair => pair.Key, pair => pair.Value);


        }

        public Dictionary<string, int> getTopTen(Dictionary<string, int> input)
        {
            input = input.Take(10).ToDictionary<KeyValuePair<string, int>, string, int>(pair => pair.Key, pair => pair.Value);

            return input;
        }



        // ============
        // Function to get the thesaurus equivalents of the top 10 used words in the sentiment group
        public List<RootObject> getThesaurus(Dictionary<string, int> input)
        {

            var topTenWords = input.Keys.Take(10).ToList();

            var thesaurus = new List<RootObject>();
            foreach (var word in topTenWords)
            {
                thesaurus.Add(getThesaurus(word));
            }

            return thesaurus;

        }

        public RootObject getThesaurus(string word)
        {
            string str = String.Empty;
            RootObject r = new RootObject();
            using (var http = new WebClient())
            {
                try
                {
                    str = http.DownloadString($"http://words.bighugelabs.com/api/2/{API_KEY}/{word}/json");
                    r = JsonConvert.DeserializeObject<RootObject>(str);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return r;
        }


    }
    public class Noun
    {
        public List<string> syn { get; set; }
        public List<string> ant { get; set; }
        public List<string> usr { get; set; }
    }

    public class Verb
    {
        public List<string> syn { get; set; }
        public List<string> ant { get; set; }
    }

    public class RootObject
    {
        public Noun noun { get; set; }
        public Verb verb { get; set; }
    }

}
