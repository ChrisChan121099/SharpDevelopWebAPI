/*
 * Created by SharpDevelop.
 * User: Chan
 * Date: 11/25/2020
 * Time: 12:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Students.
	/// </summary>
	public class Students : Person
    {
        public string SchoolLastAttended{ get; set; }
        public Course CourseId{ get; set; }
       
        [NotMapped]
        public string Photo { get; set; }        
        [JsonIgnore]
        public byte[] PhotoData { get; set; }
    }
}
