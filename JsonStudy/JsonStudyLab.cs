using JsonStudy.Models;
using Newtonsoft.Json;
using System;
using Xunit;
using JsonStudy.Utils;

namespace JsonStudy
{
    //https://www.codeproject.com/Articles/1201466/Working-with-JSON-in-Csharp-VB
    public class JsonStudyLab
    {
        [Fact]
        public void SimpleObjectTypes()
        {
            #region InputJson
            string InputJson =
                @"{
                        'category_id': 68890752,
                        'name': 'gloves',
                        'meta_title': 'Handmade Gloves on Etsy - Gloves, mittens, arm warmers',
                        'meta_keywords': 'handmade gloves, gloves, handmade arm warmers, handmade fingerless gloves, handmade mittens, hand knit mittens, hand knit gloves, handmade accessories',
                        'meta_description': 'Shop for unique, handmade gloves on Etsy, a global handmade marketplace. Browse gloves, arm warmers, fingerless gloves & more from independent artisans.',
                        'page_description': 'Shop for unique, handmade gloves from our artisan community',
                        'page_title': 'Handmade gloves',
                        'category_name': 'accessories\/gloves',
                        'short_name': 'Gloves',
                        'long_name': 'Accessories > Gloves',
                        'num_children': 3
                }";
            #endregion

            Category Result = JsonHelper.ToClass<Category>(InputJson);

            Assert.True(true);
        }

        [Fact]
        public void SimpleCollectionTypes()
        {
            #region InputJson
            string InputJson =
            @"{
    'count': 27,
    'results': [{
        'category_id': 68890752,
        'name': 'gloves',
        'meta_title': 'Handmade Gloves on Etsy - Gloves, mittens, arm warmers',
        'meta_keywords': 'handmade gloves, gloves, handmade arm warmers, handmade fingerless gloves, handmade mittens, hand knit mittens, hand knit gloves, handmade accessories',
        'meta_description': 'Shop for unique, handmade gloves on Etsy, a global handmade marketplace. Browse gloves, arm warmers, fingerless gloves & more from independent artisans.',
        'page_description': 'Shop for unique, handmade gloves from our artisan community',
        'page_title': 'Handmade gloves',
        'category_name': 'accessories\/gloves',
        'short_name': 'Gloves',
        'long_name': 'Accessories > Gloves',
        'num_children': 3
    },
    {
        'category_id': 68890784,
        'name': 'mittens',
        'meta_title': 'Handmade Mittens on Etsy - Mittens, gloves, arm warmers',
        'meta_keywords': 'handmade mittens, handcrafted mittens, mittens, accessories, gloves, arm warmers, fingerless gloves, mittens, etsy, buy handmade, shopping',
        'meta_description': 'Shop for unique, handmade mittens on Etsy, a global handmade marketplace. Browse mittens, arm warmers, fingerless gloves & more from independent artisans.',
        'page_description': 'Shop for unique, handmade mittens from our artisan community',
        'page_title': 'Handmade mittens',
        'category_name': 'accessories\/mittens',
        'short_name': 'Mittens',
        'long_name': 'Accessories > Mittens',
        'num_children': 4
    }],
    'params': {
        'tag': 'accessories'
    },
    'type': 'Category',
    'pagination': {
        
    }
}";
            #endregion

            // Convert to C# Class typed object
            var response = JsonHelper.ToClass<Response<Category>>(InputJson);


            Assert.True(true);
        }
    }
}
