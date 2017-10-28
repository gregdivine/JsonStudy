using JsonStudy.Models;
using Newtonsoft.Json;
using System;
using Xunit;
using JsonStudy.Utils;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
            var response = JsonHelper.ToClass<ServerResponse_UpdateTime>(InputJson);

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

        [Fact]
        public void MultiValueTypeCollections()
        {
            #region InputJson
            string InputJson =
                @"
                    {
  ""page"": 1,
  ""total_results"": 3433,
  ""total_pages"": 172,
  ""results"": [
    {
      ""original_name"": ""Captain N and the New Super Mario World"",
      ""id"": 26732,
      ""media_type"": ""tv"",
      ""name"": ""Captain N and the New Super Mario World"",
      ""vote_count"": 2,
      ""vote_average"": 3.5,
      ""poster_path"": ""/i4Q8a0Ax5I0h6b1rHOcQEZNvJzG.jpg"",
      ""first_air_date"": ""1991-09-14"",
      ""popularity"": 1.479857,
      ""genre_ids"": [
        16,
        35
      ],
      ""original_language"": ""en"",
      ""backdrop_path"": ""/iYT5w3Osv3Bg1NUZdN9UYmVatPs.jpg"",
      ""overview"": ""Super Mario World is an American animated television series loosely based on the Super NES video game of the same name. It is the third and last Saturday morning cartoon based on the Super Mario Bros. NES and Super NES series of video games. The show only aired 13 episodes due to Captain N: The Game Master's cancellation on NBC. Just like The Adventures of Super Mario Bros. 3, the series is produced by DIC Entertainment and Reteitalia S.P.A in association with Nintendo, who provided the characters and power-ups from the game."",
      ""origin_country"": [
        ""US""
      ]
    },
    {
      ""popularity"": 1.52,
      ""media_type"": ""person"",
      ""id"": 1435599,
      ""profile_path"": null,
      ""name"": ""Small World"",
      ""known_for"": [
        {
          ""vote_average"": 8,
          ""vote_count"": 1,
          ""id"": 329083,
          ""video"": false,
          ""media_type"": ""movie"",
          ""title"": ""One For The Road: Ronnie Lane Memorial Concert"",
          ""popularity"": 1.062345,
          ""poster_path"": ""/i8Ystwg81C3g9a5z3ppt3yO1vkS.jpg"",
          ""original_language"": ""en"",
          ""original_title"": ""One For The Road: Ronnie Lane Memorial Concert"",
          ""genre_ids"": [
            10402
          ],
          ""backdrop_path"": ""/oG9uoxtSuokJBgGO4XdC5m4uRGU.jpg"",
          ""adult"": false,
          ""overview"": ""At The Royal Albert Hall, London on 8th April 2004 after some 15 months of planning with Paul Weller, Ronnie Wood, Pete Townshend, Steve Ellis, Midge Ure, Ocean Colour Scene amongst them artists assembled to perform to a sell-out venue and to pay tribute to a man who co-wrote many Mod anthems such as \""\""Itchycoo Park, All Or Nothing, Here Comes The Nice, My Mind's Eye\""\"" to name just a few. Ronnie Lane was the creative heart of two of Rock n Rolls quintessentially English groups, firstly during the 60's with The Small Faces then during the 70;s with The Faces. After the split of the Faces he then formed Slim Chance and toured the UK in a giant circus tent as well as working in the studio with Eric Clapton, Pete Townshend and Ronnie Wood. 5,500 fans looked on in awe at The R.A.H as the superb evening's entertainment ended with \""\""All Or Nothing\""\"" featuring a surprise appearance by Chris Farlowe on lead vocals."",
          ""release_date"": ""2004-09-24""
        }
      ],
      ""adult"": false
    },
    {
      ""vote_average"": 6.8,
      ""vote_count"": 4429,
      ""id"": 76338,
      ""video"": false,
      ""media_type"": ""movie"",
      ""title"": ""Thor: The Dark World"",
      ""popularity"": 10.10431,
      ""poster_path"": ""/bnX5PqAdQZRXSw3aX3DutDcdso5.jpg"",
      ""original_language"": ""en"",
      ""original_title"": ""Thor: The Dark World"",
      ""genre_ids"": [
        28,
        12,
        14
      ],
      ""backdrop_path"": ""/3FweBee0xZoY77uO1bhUOlQorNH.jpg"",
      ""adult"": false,
      ""overview"": ""Thor fights to restore order across the cosmos… but an ancient race led by the vengeful Malekith returns to plunge the universe back into darkness. Faced with an enemy that even Odin and Asgard cannot withstand, Thor must embark on his most perilous and personal journey yet, one that will reunite him with Jane Foster and force him to sacrifice everything to save us all."",
      ""release_date"": ""2013-10-29""
    }
  ]
}
                 ";
            #endregion

            var response = JsonHelper.ToClass<ResponseMovieDBOrg>(InputJson);
        }

        [Fact]
        public void GoogleDrive()
        {
            #region InputJson
            string InputJson =
                @"
                    {
 ""kind"": ""drive#fileList"",
 ""incompleteSearch"": false,
 ""files"": [
  {
   ""kind"": ""drive#file"",
   ""mimeType"": ""video/mp4""
  },
  {
   ""kind"": ""drive#file"",
   ""mimeType"": ""application/vnd.google-apps.folder""
  },
  {
   ""kind"": ""drive#file"",
   ""mimeType"": ""application/vnd.openxmlformats-officedocument.presentationml.presentation""
  },
  {
   ""kind"": ""drive#file"",
   ""mimeType"": ""application/vnd.openxmlformats-officedocument.wordprocessingml.document""
  },
  {
   ""kind"": ""drive#file"",
   ""mimeType"": ""text/plain""
  },
  {
   ""kind"": ""drive#file"",
   ""mimeType"": ""image/png""
  }
 ]
}
                 ";
            #endregion

            var response = JsonHelper.ToClass<ResponseGoogleDrive>(InputJson);
        }

    }
}
