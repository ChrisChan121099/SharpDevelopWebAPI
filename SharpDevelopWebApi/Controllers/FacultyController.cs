using System;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of FacultyController.
	/// </summary>
	public class FacultyController : ApiController
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
            var faculty = _db.Faculties.Find(Id);
            if (faculty != null)
                return Ok(faculty);
            else
                return BadRequest("Faculty not found");
        }

        //[ApiAuthorize]
        [HttpPost]
        public IHttpActionResult Create(Faculty newFaculty)
        {
            _db.Faculties.Add(newFaculty);
            _db.SaveChanges();
            return Ok(newFaculty);
        }

        [HttpPut]
        public IHttpActionResult Update(Faculty updatedFaculty)
        {
        	var faculty = _db.Faculties.Find(updatedFaculty.Id);
            if (faculty != null)
            {
                faculty.SSSNumber = updatedFaculty.SSSNumber;
                faculty.Supervisor = updatedFaculty.Supervisor;
              

                _db.Entry(faculty).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(faculty);
            }
            else
                return BadRequest("Faculty not found");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var faculty = _db.Faculties.Find(Id);
            if (faculty != null)
            {
                _db.Faculties.Remove(faculty);
                _db.SaveChanges();
                return Ok("Faculty successfully deleted");
            }
            else
                return BadRequest("Faculty not found");
        }
        
//        [HttpPost]
//        [FileUpload.SwaggerForm()]
//        [Route("api/customer/{Id}/uploadphoto")]
//        public IHttpActionResult UploadPhoto(int Id)
//        {            
//            var faculty = _db.Faculties.Find(Id);
//            if (faculty != null)
//            {
//	        	var postedFile = HttpContext.Current.Request.Files[0];
//            	var filePath = postedFile.SaveAsJpegFile();
//            	if(!string.IsNullOrEmpty(filePath))
//            	{
//	            	faculty.PhotoUrl = filePath;
//	
//	                _db.Entry(faculty).State = System.Data.Entity.EntityState.Modified;
//	                _db.SaveChanges();
//	
//	                return Ok(faculty);            		
//            	}
//            }
//                       
//            return BadRequest("Error on photo uploading...");
//        }
    }
}