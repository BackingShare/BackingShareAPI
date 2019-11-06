using System;
using System.Collections.Generic;
using Backing_Share___API.Helpers;
using Backing_Share___API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backing_Share___API.Controllers
{
    [EnableCors("MyPolicy")]
    public class ProjectsController : Controller
    {
        private IProjectsHelper _projectsHelper;

        public ProjectsController(IProjectsHelper projectsHelper)
        {
            _projectsHelper = projectsHelper;
        }
        // GET: Projects
        public List<ProjectsModel> Get(int userId)
        {
            try
            {
                List<ProjectsModel> projects = _projectsHelper.GetProjectsByUserId(userId);
                return projects;
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
           

        }
        public List<ProjectsModel> Get()
        {
            try
            {
                List<ProjectsModel> projects = _projectsHelper.GetAllProjects();
                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }



        }

        // GET: Projects/Details/5


        // GET: Projects/Create


        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectsModel projectModel)
        {
            try
            {
                _projectsHelper.Create(projectModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Projects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}