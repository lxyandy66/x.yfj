﻿using System;
using System.Collections.Generic;
using System.Linq;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.app.user.coop
{
    public class deal : xu
    {
        public int cpid { get; set; }
        public decimal price { get; set; }
        public string etime { get; set; }

        protected override void Validate()
        {
            base.Validate();
            Validator.CheckRange("cpid", cpid, -1, null);
        }

        protected override XResp Execute()
        {
            if (us.level != 10) throw new XExcep("权限不够！");

            var rent = DB.x_rent.SingleOrDefault(o => o.coop_id == cpid && o.status == 1);
            if (rent == null) throw new XExcep("x0005");

            rent.d_price = price == 0 ? rent.x_coop.price : price;
            rent.e_time = etime;
            rent.x_coop.intime = etime;
            rent.d_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            rent.status = 2;
            rent.x_coop.status = 2;

            SubmitDBChanges();

            return new XResp();
        }
    }
}
