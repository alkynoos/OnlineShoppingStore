﻿using Newtonsoft.Json;
using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        // GET: Admin


        

        public ActionResult Dashboard()
        {
            return View();
        }

        #region Album

        public List<SelectListItem> GetAlbum()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var album = _unitOfWork.GetRepositoryInstance<Album>().GetAllRecords();
            foreach (var item in album)
            {
                list.Add(new SelectListItem { Value = item.AlbumId.ToString(), Text = item.AlbumName });
            }
            return list;
        }

        
        public ActionResult Album()
        {
            
            //ViewBag.ArtistList = GetArtist();
            return View(_unitOfWork.GetRepositoryInstance<Album>().GetProduct());
        }

        public ActionResult AlbumEdit(int albumId)
        {
           
            ViewBag.ArtistList = GetArtist();
            return View(_unitOfWork.GetRepositoryInstance<Album>().GetFirstorDefault(albumId));
        }

        [HttpPost]
        public ActionResult AlbumEdit(Album tbl)
        {            
            _unitOfWork.GetRepositoryInstance<Album>().Update(tbl);
            return RedirectToAction("Album");
        }

        public ActionResult AlbumAdd()
        {

            ViewBag.ArtistList = GetArtist();
            return View();
        }


        [HttpPost]
        public ActionResult AlbumAdd(Album tbl)
        {

            _unitOfWork.GetRepositoryInstance<Album>().Add(tbl);
            return RedirectToAction("Album");
        }

        public ActionResult DeleteAlbum(int? albumId)
        {
            if (albumId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = _unitOfWork.GetRepositoryInstance<Album>().GetFirstorDefault(albumId);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        [HttpPost, ActionName("DeleteAlbum")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAlbumConfirmed(int albumId)
        {
            Album album = _unitOfWork.GetRepositoryInstance<Album>().GetFirstorDefault(albumId);
            _unitOfWork.GetRepositoryInstance<Album>().Remove(album);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Album");
        }



        #endregion

        #region Artist


        public List<SelectListItem> GetArtist()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var artist = _unitOfWork.GetRepositoryInstance<Artist>().GetAllRecords();
            foreach (var item in artist)
            {
                list.Add(new SelectListItem { Value = item.ArtistId.ToString(), Text = item.Name });
            }
            return list;
        }

        public ActionResult Artist()
        {
            return View(_unitOfWork.GetRepositoryInstance<Artist>().GetProduct());
        }

        public ActionResult ArtistEdit(int artistId)
        {
            ViewBag.ArtistList = GetArtist();
            return View(_unitOfWork.GetRepositoryInstance<Artist>().GetFirstorDefault(artistId));
        }

        [HttpPost]
        public ActionResult ArtistEdit(Artist tbl)
        {            

            //tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Artist>().Update(tbl);
            return RedirectToAction("Artist");
        }

        public ActionResult ArtistAdd()
        {
            //check if it is needed
            ViewBag.ArtistList = GetArtist();
            return View();
        }


        [HttpPost]
        public ActionResult ArtistAdd(Artist tbl)
        {
            //tbl.CreatedDate = DateTime.Now;
            
            _unitOfWork.GetRepositoryInstance<Artist>().Add(tbl);
            return RedirectToAction("Artist");
        }

        public ActionResult DeleteArtist(int? artistId)
        {
            if (artistId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = _unitOfWork.GetRepositoryInstance<Artist>().GetFirstorDefault(artistId);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost, ActionName("DeleteArtist")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArtistConfirmed(int artistId)
        {
            Artist artist = _unitOfWork.GetRepositoryInstance<Artist>().GetFirstorDefault(artistId);
            _unitOfWork.GetRepositoryInstance<Artist>().Remove(artist);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Artist");
        }

        #endregion

        

        #region Category 

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var category = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecords();
            foreach (var item in category)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }

        public ActionResult Category()
        {
            return View(_unitOfWork.GetRepositoryInstance<Category>().GetProduct());
        }

        public ActionResult CategoryEdit(int categoryId)
        {

            ViewBag.ArtistList = GetArtist();
            return View(_unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(categoryId));
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category tbl)
        {

            //tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Category>().Update(tbl);
            return RedirectToAction("Category");
        }

        public ActionResult CategoryAdd()
        {


            return View();
        }


        [HttpPost]
        public ActionResult CategoryAdd(Category tbl)
        {
            tbl.IsActive = true;
            _unitOfWork.GetRepositoryInstance<Category>().Add(tbl);
            return RedirectToAction("Category");
        }

        public ActionResult DeleteCategory(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(categoryId);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(int categoryId)
        {
            Category category = _unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(categoryId);
            _unitOfWork.GetRepositoryInstance<Category>().Remove(category);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Category");
        }


        #endregion


        #region Products



        public ActionResult Product()
        {
            ViewBag.AlbumList = GetAlbum();

            
            
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetProduct());
        }

        public ActionResult ProductEdit(int productId)
        {
            ViewBag.ArtistList = GetArtist();
            ViewBag.AlbumList = GetAlbum();
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Product>().GetFirstorDefault(productId));
        }
        
        [HttpPost]
        public ActionResult ProductEdit(Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg"), pic);
                //file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = file != null ? pic : tbl.ProductImage;

            tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Product>().Update(tbl);
            return RedirectToAction("Product");
        }
        
        public ActionResult ProductAdd()
        {
            ViewBag.ArtistList = GetArtist();
            ViewBag.AlbumList = GetAlbum();
            ViewBag.CategoryList = GetCategory();
            return View();
        }


        [HttpPost]
        public ActionResult ProductAdd(Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file !=null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg"), pic);
                //file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;
            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Product>().Add(tbl);
            return RedirectToAction("Product");
        }

        public ActionResult DeleteProduct(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _unitOfWork.GetRepositoryInstance<Product>().GetFirstorDefault(productId);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductConfirmed(int productId)
        {
            Product product = _unitOfWork.GetRepositoryInstance<Product>().GetFirstorDefault(productId);
            _unitOfWork.GetRepositoryInstance<Product>().Remove(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Product");
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
