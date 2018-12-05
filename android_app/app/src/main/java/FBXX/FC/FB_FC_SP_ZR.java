package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.math.BigDecimal;
import Common.Base;
import Common.WheelStyle;
import Entities.FB_FC_SP_Model;

public class FB_FC_SP_ZR extends Base implements View.OnClickListener {

    public FB_FC_SP_Model fb_fc_sp = new FB_FC_SP_Model();
    public TextView mtvsplx;
    public TextView mtvlxrsf;
    public TextView mtvlxrlxdh;
    public TextView mtvlc;
    public TextView mtvmj;
    public TextView mtvmk;
    public TextView mtvcg;
    public TextView mtvjs;
    public TextView mtvjyzt;
    public TextView mtvjyhy;
    public TextView mtvzj;
    public TextView mtvyffs;
    //自定义的弹出框类
    FB_FC_LXRSF lxrsfWindow;
    FB_FC_LXRLXDH lxrlxdhWindow;
    FB_FC_SP_SPLX splxWindow;
    FB_FC_MJ mjWindow;
    FB_FC_SP_MKCGJS mkcgjsWindow;
    FB_FC_SP_JYZT jyztWindow;
    FB_FC_SP_JYHY jyhyWindow;
    FB_FC_ZJ zjWindow;
    FB_FC_SP_LC lcWindow;
    FB_FC_YFFS yffsWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_sp_zr);
        initView();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_sp_lx).setOnClickListener(this);
        findViewById(R.id.ll_sp_mj).setOnClickListener(this);
        findViewById(R.id.ll_sp_mk).setOnClickListener(this);
        findViewById(R.id.ll_sp_cg).setOnClickListener(this);
        findViewById(R.id.ll_sp_js).setOnClickListener(this);
        findViewById(R.id.ll_sp_jyzt).setOnClickListener(this);
        findViewById(R.id.ll_sp_jyhy).setOnClickListener(this);
        findViewById(R.id.ll_sp_zj).setOnClickListener(this);
        findViewById(R.id.ll_sp_lc).setOnClickListener(this);
        findViewById(R.id.ll_sp_yffs).setOnClickListener(this);
        findViewById(R.id.tv_dbcd_nextstep).setOnClickListener(this);

        mtvsplx = (TextView) findViewById(R.id.tv_sp_lx);
        mtvmj = (TextView) findViewById(R.id.tv_sp_mj);
        mtvmk = (TextView) findViewById(R.id.tv_sp_mk);
        mtvcg = (TextView) findViewById(R.id.tv_sp_cg);
        mtvjs = (TextView) findViewById(R.id.tv_sp_js);
        mtvjyzt = (TextView) findViewById(R.id.tv_sp_jyzt);
        mtvjyhy = (TextView) findViewById(R.id.tv_sp_jyhy);
        mtvzj = (TextView) findViewById(R.id.tv_sp_zj);
        mtvlc = (TextView) findViewById(R.id.tv_sp_lc);
        mtvyffs = (TextView) findViewById(R.id.tv_sp_yffs);
        mtvlxrsf = (TextView) findViewById(R.id.tv_sp_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_sp_lxrlxdh);

        mtvlxrsf.setOnClickListener(this);
        mtvlxrlxdh.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC_SP_LB");
                break;
            case R.id.tv_dbcd_nextstep:
                YMTZ("FB_FC_SP_ZR2");
                break;
            case R.id.tv_sp_lxrsf:
                YMTZ("FB_FC_LXRSF");
                break;
            case R.id.tv_sp_lxrlxdh:
                YMTZ("FB_FC_LXRLXDH");
                break;
            case R.id.ll_sp_lx:
                YMTZ("FB_FC_SP_SPLX");
                break;
            case R.id.ll_sp_mj:
                YMTZ("FB_FC_MJ");
                break;
            case R.id.ll_sp_mk:
                YMTZ("FB_FC_SP_MK");
                break;
            case R.id.ll_sp_cg:
                YMTZ("FB_FC_SP_CG");
                break;
            case R.id.ll_sp_js:
                YMTZ("FB_FC_SP_JS");
                break;
            case R.id.ll_sp_jyzt:
                YMTZ("FB_FC_SP_JYZT");
                break;
            case R.id.ll_sp_jyhy:
                YMTZ("FB_FC_SP_JYHY");
                break;
            case R.id.ll_sp_zj:
                YMTZ("FB_FC_ZJ");
                break;
            case R.id.ll_sp_lc:
                YMTZ("FB_FC_SP_LC");
                break;
            case R.id.ll_sp_yffs:
                YMTZ("FB_FC_YFFS");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC_SP_LB") {
            Intent intent = new Intent(FB_FC_SP_ZR.this, FB_FC_SP_LB.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_SP_ZR2") {
            Intent intent = new Intent(FB_FC_SP_ZR.this, FB_FC_SP_ZR2.class);
            Bundle bundle = new Bundle();
            bundle.putSerializable("fb_fc_sp", fb_fc_sp);
            intent.putExtras(bundle);
            startActivity(intent);
        }
        if (id == "FB_FC_SP_SPLX") {
            splxWindow = new FB_FC_SP_SPLX(FB_FC_SP_ZR.this, splxOnClick);
            splxWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            splxWindow.SetCheck(mtvsplx.getText().toString());
        }
        if (id == "FB_FC_MJ") {
            mjWindow = new FB_FC_MJ(FB_FC_SP_ZR.this, mjOnClick);
            mjWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            mjWindow.metmj.setText(mtvmj.getText());
        }
        if (id == "FB_FC_SP_MK") {
            mkcgjsWindow = new FB_FC_SP_MKCGJS(FB_FC_SP_ZR.this, mkcgjsOnClick, "MK");
            mkcgjsWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            mkcgjsWindow.mtvmk.setText(mtvmk.getText());
            mkcgjsWindow.mtvcg.setText(mtvcg.getText());
            mkcgjsWindow.mtvjs.setText(mtvjs.getText());
        }
        if (id == "FB_FC_SP_CG") {
            mkcgjsWindow = new FB_FC_SP_MKCGJS(FB_FC_SP_ZR.this, mkcgjsOnClick, "CG");
            mkcgjsWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            mkcgjsWindow.mtvmk.setText(mtvmk.getText());
            mkcgjsWindow.mtvcg.setText(mtvcg.getText());
            mkcgjsWindow.mtvjs.setText(mtvjs.getText());
        }
        if (id == "FB_FC_SP_JS") {
            mkcgjsWindow = new FB_FC_SP_MKCGJS(FB_FC_SP_ZR.this, mkcgjsOnClick, "JS");
            mkcgjsWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            mkcgjsWindow.mtvmk.setText(mtvmk.getText());
            mkcgjsWindow.mtvcg.setText(mtvcg.getText());
            mkcgjsWindow.mtvjs.setText(mtvjs.getText());
        }
        if (id == "FB_FC_SP_JYZT") {
            jyztWindow = new FB_FC_SP_JYZT(FB_FC_SP_ZR.this, jyztOnClick);
            jyztWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            jyztWindow.SetCheck(mtvjyzt.getText().toString());
        }
        if (id == "FB_FC_SP_JYHY") {
            jyhyWindow = new FB_FC_SP_JYHY(FB_FC_SP_ZR.this, jyhyOnClick);
            jyhyWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            jyhyWindow.SetCheck(mtvjyhy.getText().toString());
        }
        if (id == "FB_FC_ZJ") {
            zjWindow = new FB_FC_ZJ(FB_FC_SP_ZR.this, zjOnClick);
            zjWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            zjWindow.metzj.setText(mtvzj.getText());
        }
        if (id == "FB_FC_SP_LC") {
            lcWindow = new FB_FC_SP_LC(FB_FC_SP_ZR.this, lcOnClick);
            lcWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            lcWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            lcWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
        }
        if (id == "FB_FC_YFFS") {
            yffsWindow = new FB_FC_YFFS(FB_FC_SP_ZR.this, yffsOnClick);
            yffsWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            yffsWindow.mwvy.setWheelItemList(WheelStyle.createYString());
            yffsWindow.mwvf.setWheelItemList(WheelStyle.createFString());
        }
        if (id == "FB_FC_LXRSF") {
            lxrsfWindow = new FB_FC_LXRSF(FB_FC_SP_ZR.this, lxrsfOnClick);
            lxrsfWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_LXRLXDH") {
            lxrlxdhWindow = new FB_FC_LXRLXDH(FB_FC_SP_ZR.this, lxrlxdhOnClick);
            lxrlxdhWindow.showAtLocation(FB_FC_SP_ZR.this.findViewById(R.id.fb_fc_sp_zr), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
    }

    //商铺类型页面按钮监听
    private View.OnClickListener splxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    splxWindow.dismiss();
                    mtvsplx.setText(splxWindow.GetCheck());
                    break;
            }
        }
    };


    //面积页面按钮监听
    private View.OnClickListener mjOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    mjWindow.dismiss();
                    break;
                case R.id.tvqd:
                    mjWindow.dismiss();
                    mtvmj.setText(mjWindow.metmj.getText());

                    fb_fc_sp.PFM = mjWindow.metmj.getText().toString();
                    break;
            }
        }
    };

    //面宽层高进深页面按钮监听
    private View.OnClickListener mkcgjsOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    mkcgjsWindow.dismiss();
                    break;
                case R.id.tv_js_qd:
                    mkcgjsWindow.dismiss();
                    mtvmk.setText(mkcgjsWindow.mtvmk.getText());
                    mtvcg.setText(mkcgjsWindow.mtvcg.getText());
                    mtvjs.setText(mkcgjsWindow.mtvjs.getText());

                    fb_fc_sp.MK = mkcgjsWindow.mtvmk.getText().toString();
                    fb_fc_sp.CG = mkcgjsWindow.mtvcg.getText().toString();
                    fb_fc_sp.JS = mkcgjsWindow.mtvjs.getText().toString();
                    break;
            }
        }
    };

    //经营状态页面按钮监听
    private View.OnClickListener jyztOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    jyztWindow.dismiss();
                    mtvjyzt.setText(jyztWindow.GetCheck());
                    break;
            }
        }
    };

    //经营行业页面按钮监听
    private View.OnClickListener jyhyOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    jyhyWindow.dismiss();
                    mtvjyhy.setText(jyhyWindow.GetCheck());
                    break;
            }
        }
    };

    //租金页面按钮监听
    private View.OnClickListener zjOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    zjWindow.dismiss();
                    break;
                case R.id.tvqd:
                    zjWindow.dismiss();
                    mtvzj.setText(zjWindow.metzj.getText());

                    fb_fc_sp.ZJ = new BigDecimal(zjWindow.metzj.getText().toString().replace("元","").replace("/","").replace("月",""));
                    break;
            }
        }
    };

    //楼层页面按钮监听
    private View.OnClickListener lcOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    lcWindow.dismiss();
                    break;
                case R.id.tv_lc_qd:
                    lcWindow.dismiss();
                    mtvlc.setText(WheelStyle.createCString().get(lcWindow.mwvc.getCurrentItem()).replace("层","") + "/" + WheelStyle.createGJCString().get(lcWindow.mwvgjc.getCurrentItem()).replace("共","").replace("层",""));

                    fb_fc_sp.C = WheelStyle.createCString().get(lcWindow.mwvc.getCurrentItem()).replace("层","");
                    fb_fc_sp.GJC = WheelStyle.createGJCString().get(lcWindow.mwvc.getCurrentItem()).replace("层","");
                    break;
            }
        }
    };

    //押付方式页面按钮监听
    private View.OnClickListener yffsOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    yffsWindow.dismiss();
                    break;
                case R.id.tv_yffs_qd:
                    yffsWindow.dismiss();
                    mtvyffs.setText(WheelStyle.createYString().get(yffsWindow.mwvy.getCurrentItem()) + WheelStyle.createFString().get(yffsWindow.mwvf.getCurrentItem()));

                    fb_fc_sp.YFFS = WheelStyle.createYString().get(yffsWindow.mwvy.getCurrentItem()) + WheelStyle.createFString().get(yffsWindow.mwvf.getCurrentItem());
                    break;
            }
        }
    };

    //联系人身份页面按钮监听
    private View.OnClickListener lxrsfOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    lxrsfWindow.dismiss();
                    mtvlxrsf.setText(lxrsfWindow.GetCheck());

                    break;
            }
        }
    };

    //联系人联系电话页面按钮监听
    private View.OnClickListener lxrlxdhOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    lxrlxdhWindow.dismiss();
                    break;
                case R.id.tvqd:
                    lxrlxdhWindow.dismiss();
                    mtvlxrlxdh.setText(lxrlxdhWindow.metLXDH.getText());

                    fb_fc_sp.LXDH = lxrlxdhWindow.metLXDH.getText().toString();
                    break;
            }
        }
    };
}
