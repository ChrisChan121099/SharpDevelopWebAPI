using System;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of CourseController.
	/// </summary>
	public class CourseController : ApiController
    {
        SDWebApiDbContext _db = new SDWebApiDbContext();
        
//        [HttpGet]
//        public IHttpActionResult GetAll(string keyword = "")
//        {
//            keyword = keyword.Trim();
//            var students = new List<Stud>();
//            if(!string.IsNullOrEmpty(keyword))
//            {
//                Students = _db.Students
//                    .Where(x => x.LastName.Contains(keyword) || x.FirstName.Contains(keyword))
//                    .ToList();
//            }
//            else
//            	Students = _db.Students.ToList();
//
//            return Ok(students);
//        }

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {       
            var course = _db.Courses.Find(Id);
            if (course != null)
                return Ok(course);
            else
                return BadRequest("Course not found");
        }

        //[ApiAuthorize]
        [HttpPost]
        public IHttpActionResult Create(Course newCourse)
        {
            _db.Courses.Add(newCourse);
            _db.SaveChanges();
            return Ok(newCourse);
        }

        [HttpPut]
        public IHttpActionResult Update(Course updatedCourse)
        {
        	var course = _db.Courses.Find(updatedCourse.Id);
            if (course != null)
            {
            	course.Id = updatedCourse.Id;
            	course.Name = updatedCourse.Name;
              
                _db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(course);
            }
            else
                return BadRequest("Course not found");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var course = _db.Courses.Find(Id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                _db.SaveChanges();
                return Ok("Course successfully deleted");
            }
            else
                return BadRequest("Course not found");
        }
//        
//        [HttpPost]
//        [FileUpload.SwaggerForm()]
//        [Route("api/customer/{Id}/uploadphoto")]
//        public IHttpActionResult UploadPhoto(int Id)
//        {            
//            var course = _db.Courses.Find(Id);
//            if (course != null)
//            {
//	        	var postedFile = HttpContext.Current.Request.Files[0];
//            	var filePath = postedFile.SaveAsJpegFile();
//            	if(!string.IsNullOrEmpty(filePath))
//            	{
//	            	course.PhotoUrl = filePath;
//	
//	                _db.Entry(course).State = System.Data.Entity.EntityState.Modified;
//	                _db.SaveChanges();
//	
//	                return Ok(course);            		
//            	}
//            }
//                       
//            return BadRequest("Error on photo uploading...");
//        }
    }
}