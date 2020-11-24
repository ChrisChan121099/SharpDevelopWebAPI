using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of StudentGradeController.
	/// </summary>
	public class StudentGradeController : ApiController
	{
		 SDWebApiDbContext _db = new SDWebApiDbContext();

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {       
            var grade = _db.Grades.Find(Id);
            if (grade != null)
                return Ok(grade);
            else
                return BadRequest("Student Grade not found");
        }

        //[ApiAuthorize]
        [HttpPost]
        public IHttpActionResult Create(StudentGrade newStudentGrade)
        {
            _db.Grades.Add(newStudentGrade);
            _db.SaveChanges();
            return Ok(newStudentGrade);
        }

        [HttpPut]
        public IHttpActionResult Update(StudentGrade updatedStudentGrade)
        {
        	var Ugrade = _db.Grades.Find(updatedStudentGrade.Id);
            if (Ugrade != null)
            {
            	Ugrade.Id = updatedStudentGrade.Id;
            	Ugrade.P1Grade = updatedStudentGrade.P1Grade;
            	Ugrade.P2Grade = updatedStudentGrade.P2Grade;
            	Ugrade.P3Grade = updatedStudentGrade.P3Grade;

             
                _db.Entry(Ugrade).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(Ugrade);
            }
            else
                return BadRequest("Student Grade not found");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var Dgrade = _db.Grades.Find(Id);
            if (Dgrade != null)
            {
                _db.Grades.Remove(Dgrade);
                _db.SaveChanges();
                return Ok("Student Grade successfully deleted");
            }
            else
                return BadRequest("Student Grade not found");
        }
    
	}
}