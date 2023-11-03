using Quiz2DB.Model;
using Quiz2DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz2.Controllers
{
    public class HomeController : Controller
    {
        IQuiz2Repository _Repo;
        ModelMapping _ModelMapping;

        public HomeController(IQuiz2Repository Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }
        public ActionResult Index()
        {
            SelectLists ddlFilter = new SelectLists();
            ddlFilter.Quiz2List = new SelectList((
                from a in _Repo.GetAddress()
                select new
                {
                    Value = a.StudentId,
                    Text = a.Type
                }).Distinct(), "Value", "Text");
            return View(ddlFilter);
        }
        [HttpGet]
        public ActionResult GetAddress(int pageIndex, int pageSize, string sortField = "Type", string sortOrder = "desc")
        {
            SelectLists ddlFilter = new SelectLists();
            IEnumerable<Quiz2DB.Quiz2> Quiz2List = null;
            IQueryable<Quiz2DB.Quiz2> Query = null;
            IEnumerable<Quiz2DB.Model.SelectLists> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(Quiz2DB.Quiz2).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {

                    Query = _Repo.GetAddress();
                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "FirstName":
                            if (sortOrder == "asc")
                            {
                                Quiz2List = Query.OrderBy(S => S.FirstName);
                            }
                            else if (sortOrder == "desc")
                            {
                                Quiz2List = Query.OrderByDescending(S => S.FirstName);
                            }
                            break;
                        case "LastName":
                            if (sortOrder == "asc")
                            {
                                Quiz2List = Query.OrderBy(S => S.LastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                Quiz2List = Query.OrderByDescending(S => S.LastName);
                            }
                            break;

                        default:
                            Quiz2List = Query.OrderByDescending(S => S.StudentId);
                            break;
                    }
                    // CommentsList = Query.OrderByDescending(S => S.CommentDate);

                    ResultList = Quiz2List.Skip(skip)
                           .Take(pageSize).ToList().ToList()
                           .Select(T => _ModelMapping.LoadAddress(T));

                    var res = Quiz2List.GroupBy(x => x.StudentId).Select(y => y.First());
                }
            }
            catch (Exception ex)
            {
                //
            }
            var Result = new { data = ResultList, itemsCount = itemsCount };
            if (Result == null)
            {
                //
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public class ResultNames
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}