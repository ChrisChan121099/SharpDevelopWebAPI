using System;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of SubjectController.
	/// </summary>
	 public class SubjectController : ApiController
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
            var subject = _db.Subjects.Find(Id);
            if (subject != null)
                return Ok(subject);
            else
                return BadRequest("Subject not found");
        }

        //[ApiAuthorize]
        [HttpPost]
        public IHttpActionResult Create(Subject newSubject)
        {
            _db.Subjects.Add(newSubject);
            _db.SaveChanges();
            return Ok(newSubject);
        }

        [HttpPut]
        public IHttpActionResult Update(Subject updatedSubject)
        {
        	var subject = _db.Subjects.Find(updatedSubject.Id);
            if (subject != null)
            {
            	subject.Id = updatedSubject.Id;
            	subject.Code = updatedSubject.Code;
            	subject.DescriptiveTitle = updatedSubject.DescriptiveTitle;

             
                _db.Entry(subject).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(subject);
            }
            else
                return BadRequest("Subject not found");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var subject = _db.Subjects.Find(Id);
            if (subject != null)
            {
                _db.Subjects.Remove(subject);
                _db.SaveChanges();
                return Ok("Subject successfully deleted");
            }
            else
                return BadRequest("Subject not found");
        }
        
//        [HttpPost]
//        [FileUpload.SwaggerForm()]
//        [Route("api/customer/{Id}/uploadphoto")]
//        public IHttpActionResult UploadPhoto(int Id)
//        {            
//            var subject = _db.Subjects.Find(Id);
//            if (subject != null)
//            {
//	        	var postedFile = HttpContext.Current.Request.Files[0];
//            	var filePath = postedFile.SaveAsJpegFile();
//            	if(!string.IsNullOrEmpty(filePath))
//            	{
//	            	subject.PhotoUrl = filePath;
//	
//	                _db.Entry(subject).State = System.Data.Entity.EntityState.Modified;
//	                _db.SaveChanges();
//	
//	                return Ok(subject);            		
//            	}
//            }
//                       
//            return BadRequest("Error on photo uploading...");
//        }
    }
}