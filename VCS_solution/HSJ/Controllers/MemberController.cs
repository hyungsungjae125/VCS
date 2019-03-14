using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSJ.Modules;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HSJ.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Searchidpw()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [Route("api/get")]
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Database db = new Database();
            return new string[] { "value1", "value2" };
        }

        [Route("api/login")]
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public ArrayList Login([FromForm] string id, [FromForm] string pw)
        {
            Hashtable param = new Hashtable();
            param.Add("@id", id);
            param.Add("@pw", pw);
            ArrayList result = new ArrayList();
            try
            {
                Database db = new Database();
                string sql = "sp_SearchMember";
                result = db.GetList(sql, param);
                db.Close();
                return result;
            }
            catch
            {
                return new ArrayList();
            }

        }

        [Route("api/signup")]
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public int Signup([FromForm] string id, [FromForm] string pw, [FromForm] string name, [FromForm] string addr, [FromForm] string num)
        {
            Hashtable param = new Hashtable();
            param.Add("@mId", id);
            param.Add("@mPw", pw);
            param.Add("@mName", name);
            param.Add("@mAddr", addr);
            param.Add("@mNumber", num);
            int result;
            try
            {
                Database db = new Database();
                string sql = "sp_InsertMember";
                result = db.NonQuery(sql, param);
                db.Close();
                return result;
            }
            catch
            {
                return 0;
            }

        }
        //[Route("api/logininfo")]
        //[EnableCors("AllowOrigin")]
        //[HttpPost]
        //public ArrayList LoginInfo([FromForm] string mNo)
        //{
        //    Hashtable param = new Hashtable();
        //    param.Add("@mNo", mNo);
        //    ArrayList result = new ArrayList();
        //    try
        //    {
        //        Database db = new Database();
        //        string sql = "sp_SearchMemberInfo";
        //        result = db.GetList(sql, param);
        //        db.Close();
        //        return result;
        //    }
        //    catch
        //    {
        //        return new ArrayList();
        //    }
        //}
    }
}