using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    class Detail : Header
    {
        private string todo;
        private int priority;

        public Detail()
        {

        }

        public string Todo
        {
            get
            {
                return todo;
            }

            set
            {
                todo = value;
            }
        }

        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }
    }
}
