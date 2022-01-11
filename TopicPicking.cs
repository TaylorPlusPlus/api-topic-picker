using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Domain
{
    public class TopicPicking
    {
        //Properties
        public string _backEndTopic {get;set;}
        private string[] _topicsBackEnd;
        private string[] _offLimitsBackEnd;
        private HashSet<string> _offLimitsBackEndSet; 
        public string _frontEndTopic{get;set;}
        private string[] _topicsFrontEnd;
        private string[] _offLimitsFrontEnd;
        private HashSet<string> _offLimitsFrontEndSet; 
        public string _devOpsTopic{get;set;}
        private string[] _topicsDevOps;
        private string[] _offLimitsDevOps;
        private HashSet<string> _offLimitsDevOpsSet; 
        private int _count = 0;
        private Random _rand = new Random();
        private int index;

        public TopicPicking()
        {
            _offLimitsBackEndSet = new HashSet<string>();
            _offLimitsDevOpsSet = new HashSet<string>();
            _offLimitsFrontEndSet = new HashSet<string>();
            GenerateOffLimitsTopics();
            GenerateAllTopics();
            FillSets();
        }

        //Methods
        public void GenerateAllTopics()
        {
            _topicsBackEnd = System.IO.File.ReadAllLines(@"files/BackEndTopics.txt");
            _topicsFrontEnd = System.IO.File.ReadAllLines(@"files/FrontEndTopics.txt");
            _topicsDevOps = System.IO.File.ReadAllLines(@"files/DevOpsTopics.txt");
        }

        public void GenerateOffLimitsTopics()
        {
        
            _offLimitsBackEnd = System.IO.File.ReadAllLines(@"files/ChosenBackEndTopics.txt");
            _offLimitsFrontEnd = System.IO.File.ReadAllLines(@"files/ChosenFrontEndTopics.txt");
            _offLimitsDevOps = System.IO.File.ReadAllLines(@"files/ChosenDevOpsTopics.txt");
        }

        private void FillSets()
        {
            foreach (string offLimitsBack in _offLimitsBackEnd)
            {
                _offLimitsBackEndSet.Add(offLimitsBack);
            }
            foreach (string offLimitsFront in _offLimitsFrontEnd)
            {
                _offLimitsFrontEndSet.Add(offLimitsFront);
            }
            foreach (string offLimitsDev in _offLimitsDevOps)
            {
                _offLimitsDevOpsSet.Add(offLimitsDev);
            }
        }

        /*
        0 = all topics finished
        1 = topic generated
        2 = loop detected
        */
        public async void ChooseTopicForBackEnd()
        {
       
            if(_offLimitsBackEnd.Length == _topicsBackEnd.Length)
            {
                return;
            }
            _count = 0;
            _rand = new Random();

            while(_count < (_offLimitsBackEnd.Length + 1)*1000)
            {
                
                index = _rand.Next(_topicsBackEnd.Length);
                        Console.WriteLine("Topic = " + _topicsBackEnd[index]);
                if(_offLimitsBackEndSet.Contains(_topicsBackEnd[index]))
                {
                    _count ++;
                }else
                {
                    _backEndTopic = _topicsBackEnd[index];
                    await WriteToFileAsync("files/ChosenBackEndTopics.txt", _backEndTopic);
                    return;
                }
            }
            return;
        }

        public async void ChooseTopicForFrontEnd()
        {
       
            if(_offLimitsFrontEnd.Length == _topicsFrontEnd.Length)
            {
                return;
            }
            _count = 0;
            _rand = new Random();

            while(_count < (_offLimitsFrontEnd.Length + 1) *1000)
            {
                
                index = _rand.Next(_topicsFrontEnd.Length);

                if(_offLimitsFrontEndSet.Contains(_topicsFrontEnd[index]))
                {
                    _count ++;
                }else
                {
                    _frontEndTopic = _topicsFrontEnd[index];
                    await WriteToFileAsync("files/ChosenFrontEndTopics.txt", _frontEndTopic);
                    return;
                }
            }
            return;
        }
         public async void ChooseTopicForDevOps()
        {       
            if(_offLimitsDevOps.Length == _topicsDevOps.Length)
            {
                return;
            }
            _count = 0;
            _rand = new Random();

            while(_count < (_offLimitsDevOps.Length + 1) *1000)
            {
                
                index = _rand.Next(_topicsDevOps.Length);
        
                if(_offLimitsDevOpsSet.Contains(_topicsDevOps[index]))
                {
                    _count ++;
                }else
                {
                    _devOpsTopic = _topicsDevOps[index];
                    Console.WriteLine("Topic Right before DevOps File Write = " + _devOpsTopic);
                    await WriteToFileAsync("files/ChosenDevOpsTopics.txt", _devOpsTopic);
                    return;
                }
            }
            return;
        }
        public async Task WriteToFileAsync(string fileName, string value)
        {
            using StreamWriter file = new(fileName, append: true);
            await file.WriteLineAsync(value);
        }

        public void ChooseTopics()
        {
            ChooseTopicForBackEnd();
            ChooseTopicForDevOps();
            ChooseTopicForFrontEnd();
        }

        public override string ToString()
        {
            string returnString ="";
            returnString += "FrontEnd topic: " + _frontEndTopic;
            returnString += "\nBackend Topic: " + _backEndTopic;
            returnString += "\nDevOps Topic: " + _devOpsTopic;
            return returnString;
        }


         public async void ChooseTopic(string type)
        {
            switch(type)
            {
                case "BackEnd":
                break;
                case "FrontEnd":
                break;
                case "DevOps":
                break;
            }
       
            if(_offLimitsDevOps.Length == _topicsDevOps.Length)
            {
                return;
            }
            _count = 0;
            _rand = new Random();

            while(_count < (_offLimitsDevOps.Length + 1) *1000)
            {
                
                index = _rand.Next(_topicsDevOps.Length);
        
                if(_offLimitsDevOpsSet.Contains(_topicsDevOps[index]))
                {
                    _count ++;
                }else
                {
                    _devOpsTopic = _topicsDevOps[index];
                    Console.WriteLine("Topic Right before DevOps File Write = " + _devOpsTopic);
                    await WriteToFileAsync("files/ChosenDevOpsTopics.txt", _devOpsTopic);
                    return;
                }
            }
            return;
        }
    }
}