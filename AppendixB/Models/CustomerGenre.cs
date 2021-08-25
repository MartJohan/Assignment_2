using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore.Models
{
    public class CustomerGenre
    {
        public Dictionary<string, int> GenreCount;

        public CustomerGenre()
        {
            GenreCount = new Dictionary<string, int>();
        }
    }
}
