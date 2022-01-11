using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using homeProjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace homeProjects.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicPickerController : ControllerBase
    {

        GroupOfTopics topics = new GroupOfTopics();
        
        public TopicPickerController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("GetCalled");
            TopicPicking picker = new TopicPicking();
            picker.ChooseTopics();
            topics.FrontEndTopic = picker._frontEndTopic;
            topics.BackEndTopic = picker._backEndTopic;
            topics.DevOpsTopic = picker._devOpsTopic;
           return Ok(topics);
        }

        [HttpPost("[action]")]
        public IActionResult PostTopic([FromBody] Topic incomingTopic)
        {
            System.Console.WriteLine(incomingTopic.Type + " " + incomingTopic.TopicName);
            return Ok();
        }
    }
}
