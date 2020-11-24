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

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of StudentGrade.
	/// </summary>
	public class StudentGrade
{

	public int Id { get; set; }
	public int StudentId { get; set; }
	public int SubjectId { get; set; }
	public double P1Grade { get; set; }
	public double P2Grade { get; set; }
	public double P3Grade { get; set; }

}
}
