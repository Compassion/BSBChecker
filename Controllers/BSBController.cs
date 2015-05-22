using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using BSBChecker.Models;

namespace BSBChecker.Controllers
{
    public class BSBController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public List<BSBData> Get(string id)
        {
            var input = cleanInput(id);
            if (input == null)
            {
                throw new ArgumentException(
                    " This is not a valid format for a BSB (try XXX-XXX or XXXXXX): {0}", id);
            }
            return WebApiApplication.TheBSBData.FindAll(obj => obj.BSB.StartsWith(input)).Take(15).ToList();
        }

        private string cleanInput(string id)
        {
            //This is not a good case at all.
            if (!Regex.Match(id, @"^[0-9-]+$").Success) return null;
            if (id.Length <= 3 && Regex.Match(id, @"^\d{1,3}$").Success) return id;
            if (id.Length >= 4 && Regex.Match(id, @"^\d{3}-?\d{0,3}$").Success)
            {             
                if (id.Length == 4)
                {
                    if (id[3].Equals('-')) return id;
                    return string.Format("{0}-{1}", id.Substring(0, 3), id.Substring(3, 1));
                }
                if (id.Length == 5)
                {
                    if (id[3].Equals('-')) return id;
                    return string.Format("{0}-{1}", id.Substring(0, 3), id.Substring(3, 2));
                }
                if (id.Length == 6)
                {
                    if (id[3].Equals('-')) return id;
                    return string.Format("{0}-{1}", id.Substring(0, 3), id.Substring(3, 3));
                }
                if (id.Length == 7 && Regex.Match(id, @"^\d\d\d-?\d\d\d$").Success) return id;
            }
            return null;
        }
    }
}