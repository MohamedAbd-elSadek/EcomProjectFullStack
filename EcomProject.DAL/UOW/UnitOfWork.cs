using EcomProject.DAL.Context;
using EcomProject.DAL.Repos.Category;
using EcomProject.DAL.Repos.Photo;
using EcomProject.DAL.Repos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommDBContext _context;
        public UnitOfWork(EcommDBContext context,
            ICategoryRepo categoryRepo,
            IProductRepo productRepo,
            IPhotoRepo photoRepo)
            // يسطا
            // انا خدت بالي من حاجه
            // injectionانا عاكس ال
        {
            // ما هو ده اللى كنت هقولهولك ياعلق 
            ////////// خخخخخخخخخخخخخخخخخخخخخخخخخخخخخخخخخخخ
            ///انا فالايرور ده من الساعه 2 ونص ودين امي
            /////يلعن كسمين ام البرمجه ان راجع مدني
            ///// LOL 
            _context = context;
            CategoryRepo = categoryRepo;
            //categoryRepo = CategoryRepo;
            ProductRepo = productRepo;
            //productRepo = ProductRepo;
            PhotoRepo = photoRepo;
            //photoRepo = PhotoRepo;
            // خخخخخخخخخخخخخخخخخخخخخخخخخخخخخخخخ
            // ضحك وعهد الله ... غيرتلى مودى وانا مكتئب ومتدشمل 
            // يعم منا بشد شعري بقالي ساعتين لحد ما بقيت شبه عم احمد نورالدين
            //بكرر الكلام مرتين 
            //بكرر الكلام مرتين
            // للأسف مفيش ايموشنز فى الفيجوال استوديو :D 
            // المهم انا هروح انام وماتنساش تدعيلى يسطا بالله عليك 
            // تصبح على خير 
            // اخويا المبرمج التنين ♥♥♥♥
        }

        public ICategoryRepo CategoryRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IPhotoRepo PhotoRepo { get; }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
