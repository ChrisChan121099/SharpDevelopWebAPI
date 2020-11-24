/*
 * Created by SharpDevelop.
 * User: Chan
 * Date: 11/25/2020
 * Time: 12:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Course.
	/// </summary>
    public class Course
    {
		public string PhotoUrl {
			get;
			set;
		}

        public int Id { get; set; }
        public string Name { get; set; }
        
//        public int CategoryId {get; set;}
//        [NotMapped]
//        public Category Category {get; set;}
//        
//        public decimal Price { get; set; }
//        
        [NotMapped]
        public string Photo { get; set; }        
        [JsonIgnore]
        public byte[] PhotoData { get; set; }
    }
}
