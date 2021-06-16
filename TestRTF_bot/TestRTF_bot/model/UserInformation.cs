using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.Controllers;
using TestRTF_bot.model;

namespace TestRTF_bot.Models
{
    public class UserInformation
    {
        private Target target;
        public int MinCost { get => Budget.MinValue; }
        public int MaxCost { get => Budget.MaxValue; }
        public ITarget TargetInterface { get; set; }
        public Target Target 
        {   get => target; 
            set 
            {
                SetTarget(value);
                target = value;
            }
        }
        public Budget Budget { get; set; }

        public UserInformation(int minCost, int maxCost, ITarget target)
        {
            this.TargetInterface = target;
            this.Budget = new Budget(minCost, maxCost);
        }

        public UserInformation()
        {

        }

        private void SetTarget(Target target)
        {
            switch (target)
            {
                case Target.Gaming:
                    TargetInterface = new GameTarget();
                    break;
                case Target.Programming:
                    TargetInterface = new ProgrammingTarget();
                    break;
                case Target.VideoEditing:
                    TargetInterface = new VideoEditingTarget();
                    break;
                case Target.Office:
                    TargetInterface = new OfficeTarget();
                    break;
            }
        }
    }
}
