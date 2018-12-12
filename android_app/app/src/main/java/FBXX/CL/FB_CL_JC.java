package FBXX.CL;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.math.BigDecimal;
import Common.Base;
import Common.WheelStyle;
import Entities.CL_JC_Model;
import FBXX.FC.FB_FC_SJ;
import LBXZ.FB_CL;

public class FB_CL_JC extends Base implements View.OnClickListener {

    public CL_JC_Model fb_cl_jc = new CL_JC_Model();
    public TextView mtvclpp;
    public TextView mtvclys;
    public TextView mtvspsj;
    public TextView mtvxslc;
    public TextView mtvywdy;
    public TextView mtvjg;

    //自定义的弹出框类
    FB_CL_JC_PP ppWindow;
    FB_CL_JC_YSSP ysspWindow;
    FB_CL_XSLC xslcWindow;
    FB_CL_JC_YWDY ywdyWindow;
    FB_FC_SJ jgWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_cl_jc);
        initView();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_jc_clpp).setOnClickListener(this);
        findViewById(R.id.ll_jc_clys).setOnClickListener(this);
        findViewById(R.id.ll_jc_spsj).setOnClickListener(this);
        findViewById(R.id.ll_jc_xslc).setOnClickListener(this);
        findViewById(R.id.ll_jc_ywdy).setOnClickListener(this);
        findViewById(R.id.ll_jc_jg).setOnClickListener(this);
        findViewById(R.id.tv_dbcd_nextstep).setOnClickListener(this);

        mtvclpp = (TextView) findViewById(R.id.tv_jc_clpp);
        mtvclys = (TextView) findViewById(R.id.tv_jc_clys);
        mtvspsj = (TextView) findViewById(R.id.tv_jc_spsj);
        mtvxslc = (TextView) findViewById(R.id.tv_jc_xslc);
        mtvywdy = (TextView) findViewById(R.id.tv_jc_ywdy);
        mtvjg = (TextView) findViewById(R.id.tv_jc_jg);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_CL");
                break;
            case R.id.tv_dbcd_nextstep:
                YMTZ("FB_CL_JC2");
                break;
            case R.id.ll_jc_clpp:
                YMTZ("FB_CL_JC_PP");
                break;
            case R.id.ll_jc_clys:
                YMTZ("FB_CL_JC_CLYS");
                break;
            case R.id.ll_jc_spsj:
                YMTZ("FB_CL_JC_SPSJ");
                break;
            case R.id.ll_jc_xslc:
                YMTZ("FB_CL_XSLC");
                break;
            case R.id.ll_jc_ywdy:
                YMTZ("FB_CL_JC_YWDY");
                break;
            case R.id.ll_jc_jg:
                YMTZ("FB_CL_JG");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_CL") {
            Intent intent = new Intent(FB_CL_JC.this, FB_CL.class);
            startActivity(intent);
            finish();
        }
        if (id == "FB_CL_JC2") {
            Intent intent = new Intent(FB_CL_JC.this, FB_CL_JC2.class);
            Bundle bundle = new Bundle();
            bundle.putSerializable("FB_CL_JC", fb_cl_jc);
            intent.putExtras(bundle);
            startActivity(intent);
        }
        if (id == "FB_CL_JC_PP") {
            ppWindow = new FB_CL_JC_PP(FB_CL_JC.this, ppOnClick);
            ppWindow.showAtLocation(FB_CL_JC.this.findViewById(R.id.fb_cl_jc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_CL_JC_CLYS") {
            ysspWindow = new FB_CL_JC_YSSP(FB_CL_JC.this, ysspOnClick,"CLYS");
            ysspWindow.showAtLocation(FB_CL_JC.this.findViewById(R.id.fb_cl_jc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            ysspWindow.mwvclys.setWheelItemList(WheelStyle.createCLYSString());
            ysspWindow.mwvyear.setWheelItemList(WheelStyle.createSPNFString());
            ysspWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            if(mtvclys.getText().toString() != "") {
                ysspWindow.mwvclys.setCurrentItem(WheelStyle.createCLYSString().indexOf(mtvclys.getText().toString()));
            }
            if(mtvspsj.getText().toString() != "") {
                ysspWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvspsj.getText().toString().substring(0, mtvspsj.getText().toString().indexOf("年") + 1)));
                ysspWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvspsj.getText().toString().substring(5, mtvspsj.getText().toString().indexOf("月") + 1)));
            }
        }
        if (id == "FB_CL_JC_SPSJ") {
            ysspWindow = new FB_CL_JC_YSSP(FB_CL_JC.this, ysspOnClick,"SPSJ");
            ysspWindow.showAtLocation(FB_CL_JC.this.findViewById(R.id.fb_cl_jc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            ysspWindow.mwvclys.setWheelItemList(WheelStyle.createCLYSString());
            ysspWindow.mwvyear.setWheelItemList(WheelStyle.createSPNFString());
            ysspWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            if(mtvclys.getText().toString() != "") {
                ysspWindow.mwvclys.setCurrentItem(WheelStyle.createCLYSString().indexOf(mtvclys.getText().toString()));
            }
            if(mtvspsj.getText().toString() != "") {
                ysspWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvspsj.getText().toString().substring(0, mtvspsj.getText().toString().indexOf("年") + 1)));
                ysspWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvspsj.getText().toString().substring(5, mtvspsj.getText().toString().indexOf("月") + 1)));
            }
        }
        if (id == "FB_CL_XSLC") {
            xslcWindow = new FB_CL_XSLC(FB_CL_JC.this, xslcOnClick);
            xslcWindow.showAtLocation(FB_CL_JC.this.findViewById(R.id.fb_cl_jc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            xslcWindow.metxslc.setText(mtvxslc.getText());
        }
        if (id == "FB_CL_JC_YWDY") {
            ywdyWindow = new FB_CL_JC_YWDY(FB_CL_JC.this, ywdyOnClick);
            ywdyWindow.showAtLocation(FB_CL_JC.this.findViewById(R.id.fb_cl_jc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            ywdyWindow.SetCheck(mtvywdy.getText().toString());
        }
        if (id == "FB_CL_JG") {
            jgWindow = new FB_FC_SJ(FB_CL_JC.this, jgOnClick);
            jgWindow.showAtLocation(FB_CL_JC.this.findViewById(R.id.fb_cl_jc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            jgWindow.metsj.setText(mtvjg.getText());
        }
    }

    //品牌页面按钮监听
    private View.OnClickListener ppOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_qtlx_qd:
                    ppWindow.dismiss();
                    break;
            }
        }
    };

    //颜色上牌页面按钮监听
    private View.OnClickListener ysspOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    ysspWindow.dismiss();
                    break;
                case R.id.tv_spsj_qd:
                    ysspWindow.dismiss();
                    mtvclys.setText(ysspWindow.mtvclys.getText());
                    mtvspsj.setText(WheelStyle.createSPNFString().get(ysspWindow.mwvyear.getCurrentItem()) + WheelStyle.createMonthString().get(ysspWindow.mwvmonth.getCurrentItem()));

                    fb_cl_jc.CLYS = ysspWindow.mtvclys.getText().toString();
                    break;
            }
        }
    };

    //行驶里程页面按钮监听
    private View.OnClickListener xslcOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    xslcWindow.dismiss();
                    break;
                case R.id.tvqd:
                    xslcWindow.dismiss();
                    mtvxslc.setText(xslcWindow.metxslc.getText());

                    fb_cl_jc.XSLC = new BigDecimal(xslcWindow.metxslc.getText().toString().replace("万公里",""));
                    break;
            }
        }
    };

    //有无抵押页面按钮监听
    private View.OnClickListener ywdyOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    ywdyWindow.dismiss();
                    mtvywdy.setText(ywdyWindow.GetCheck());
                    break;
            }
        }
    };

    //价格页面按钮监听
    private View.OnClickListener jgOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    jgWindow.dismiss();
                    break;
                case R.id.tvqd:
                    jgWindow.dismiss();
                    mtvjg.setText(jgWindow.metsj.getText());

                    fb_cl_jc.XSLC = new BigDecimal(jgWindow.metsj.getText().toString().replace("万元",""));
                    break;
            }
        }
    };
}
