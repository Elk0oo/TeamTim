﻿using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class IdentifyFaceController : ApiController
    {
        // GET: api/IdentifyFace

        Repository r;
        public IdentifyFaceController()
        {
            r = new Repository();
        }


        [HttpGet]
        [Route("api/GetImageEtape/{imgEtape}/{idPlayer}")]
        public string GetImageEtape (string imgEtape,int idPlayer)
        {
            return r.GetImageEtape("ftp://51.144.166.162/EtapePhoto/"+imgEtape+".jpg",idPlayer);
        }

        // GET: api/IdentifyFace/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/IdentifyFace
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IdentifyFace/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IdentifyFace/5
        public void Delete(int id)
        {
        }
    }
}
