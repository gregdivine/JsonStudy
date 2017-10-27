using JsonStudy.Models;
using Newtonsoft.Json;
using System;
using Xunit;
using JsonStudy.Utils;
using Newtonsoft.Json.Linq;

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

        [Fact]
        public void UNIXEpochTimestamps()
        {
            #region InputJson
            string InputJson = 
                @"{
                      'responseData': {
                        'time': '1509107180',
                        '__class__': 'Time'
                      },
                      'requestClass': 'TimeService',
                      'requestMethod': 'updateTime',
                      'requestId': 13,
                      '__class__': 'ServerResponse'
                  }";
            #endregion

            // Convert to C# Class typed object
            var response = JsonHelper.ToClass <ServerResponse_UpdateTime>(InputJson);

            Assert.True(DateTime.TryParse("27.10.2017 15:26:20", out DateTime correctTime)); //{27.10.2017 15:26:20} Correct Local Time for 1509107180

            Assert.NotNull(response);
            Assert.Equal(correctTime, response.ResponseData.Time);

            var json = JsonHelper.FromClass(response);
            Assert.True(json.Contains("1509107180"));
        }

        [Fact]
        public void FlatteningCollectionTypes()
        {
            #region InputJson
            string InputJson =
                @"
                    {
                      ""notes"": {
                        ""note"": [
                          {
                            ""id"": ""72157613689748940"",
                            ""author"": ""22994517@N02"",
                            ""authorname"": ""morningbroken"",
                            ""authorrealname"": """",
                            ""authorispro"": 0,
                            ""x"": ""227"",
                            ""y"": ""172"",
                            ""w"": ""66"",
                            ""h"": ""31"",
                            ""_content"": ""Maybe ~ I think  ...She is very happy .""
                          },
                          {
                            ""id"": ""72157622673125344"",
                            ""author"": ""40684115@N06"",
                            ""authorname"": ""Suvcon"",
                            ""authorrealname"": """",
                            ""authorispro"": 0,
                            ""x"": ""303"",
                            ""y"": ""114"",
                            ""w"": ""75"",
                            ""h"": ""60"",
                            ""_content"": ""this guy is different.""
                          }
                        ]
                      }
                    }
                 ";
            #endregion

            var photo = JsonHelper.ToClass<Photo>(InputJson);

            //var reverse = JsonHelper.FromClass(photo); // WriteJson isn't implemented
        }
    }
}
