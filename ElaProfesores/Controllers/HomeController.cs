﻿using System; using System.Collections.Generic; using System.Diagnostics; using System.Linq; using System.Threading.Tasks; using Microsoft.AspNetCore.Mvc; using Profesores.Models;  namespace Profesores.Controllers {     public class HomeController : Controller     {         List<Profesores.Models.Profesores> listado = new List<Profesores.Models.Profesores>();          public HomeController()         {             listado             .Add(new Models.Profesores() { nombrecompleto = "Juan Soto Riquelme", rut = "14.252.252 - 1", titulo = "Ingeniero Civil Informático", grado = "Ingeniero" });             listado             .Add(new Models.Profesores() { nombrecompleto = "María Ester Rosas Sotomayor", rut = "11.112.252 - 1", titulo = "Técnico Analista y Programador", grado = "Técnico" });             listado             .Add(new Models.Profesores() { nombrecompleto = "Pedro Urdemalez Pérez", rut = "20.252.252 - 1", titulo = "Phd Ciencias de la Computación", grado = "Doctor" });          }         public IActionResult Formulario()         {              return View(new Profesores.Models.Profesores());         }         public IActionResult Listado()         {             return View(listado);         }           public IActionResult Ficha(string rut, string nombrecompleto, string titulo, string grado)         {             Profesores.Models.Profesores nueva = new Models.Profesores()             {                 rut = rut,                 nombrecompleto = nombrecompleto,                 titulo = titulo,                 grado = grado             };              return View(nueva);          }          private Profesores.Models.Profesores BuscarProfesores(string rut)         {             Profesores.Models.Profesores nueva = new Models.Profesores();             foreach (Profesores.Models.Profesores profesores in listado)             {                 if (profesores.rut == rut)                 {                     nueva = profesores;                 }             }             return nueva;         }          public IActionResult Visualizar(string rut)         {             Profesores.Models.Profesores nueva = BuscarProfesores(rut);              if (nueva != null)             {                 return View("Ficha", nueva);             }             return View("Listado", listado);         }       } } 