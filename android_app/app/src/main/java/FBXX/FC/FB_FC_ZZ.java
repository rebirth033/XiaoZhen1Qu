package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.math.BigDecimal;
import java.util.List;
import Common.Base;
import Common.EditPicture;
import Common.WheelStyle;
import Entities.FB_FC_ZZ_Model;
import LBXZ.FB_FC;

public class FB_FC_ZZ extends Base implements View.OnClickListener {

    public FB_FC_ZZ_Model fb_fc_zz = new FB_FC_ZZ_Model();
    public TextView mtvxqmc;
    public TextView mtvmj;
    public TextView mtvzj;
    public TextView mtvts;
    public TextView mtvcx;
    public TextView mtvlc;
    public TextView mtvcw;
    public TextView mtvdt;
    public TextView mtvyffs;
    public TextView mtvzjbhfy;
    public TextView mtvlxrsf;
    public TextView mtvlxrlxdh;
    //自定义的弹出框类
    FB_FC_XQCX xqcxWindow;
    FB_FC_MJ mjWindow;
    FB_FC_ZJ zjWindow;
    FB_FC_FWQK fwqkWindow;
    FB_FC_CWDT cwdtWindow;
    FB_FC_ZJBHFY zjbhfyWindow;
    FB_FC_LXRSF lxrsfWindow;
    FB_FC_LXRLXDH lxrlxdhWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_zz);
        Intent intent = getIntent();
        initView();
        String XQMC = intent.getStringExtra("XQMC");
        String YMMC = intent.getStringExtra("YMMC");
        if(YMMC.equalsIgnoreCase("FB_FC_XQCX"))
            mtvxqmc.setText(XQMC);
    }

    //初始化页面
    private void initView() {
        mtvxqmc = (TextView) findViewById(R.id.tv_zz_xqmc);
        mtvmj = (TextView) findViewById(R.id.tv_zz_mj);
        mtvts = (TextView) findViewById(R.id.tv_zz_ts);
        mtvcx= (TextView) findViewById(R.id.tv_zz_cx);
        mtvlc = (TextView) findViewById(R.id.tv_zz_lc);
        mtvcw = (TextView) findViewById(R.id.tv_zz_cw);
        mtvdt = (TextView) findViewById(R.id.tv_zz_dt);
        mtvzj = (TextView) findViewById(R.id.tv_zz_zj);
        mtvyffs = (TextView) findViewById(R.id.tv_zz_yffs);
        mtvzjbhfy = (TextView) findViewById(R.id.tv_zz_zjbhfy);
        mtvlxrsf = (TextView) findViewById(R.id.tv_zz_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_zz_lxrlxdh);

        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.iv_sczp).setOnClickListener(this);
        findViewById(R.id.ll_zz_xqmc).setOnClickListener(this);
        findViewById(R.id.ll_zz_mj).setOnClickListener(this);
        findViewById(R.id.ll_zz_ts).setOnClickListener(this);
        findViewById(R.id.ll_zz_cx).setOnClickListener(this);
        findViewById(R.id.ll_zz_lc).setOnClickListener(this);
        findViewById(R.id.ll_zz_cw).setOnClickListener(this);
        findViewById(R.id.ll_zz_dt).setOnClickListener(this);
        findViewById(R.id.ll_zz_zj).setOnClickListener(this);
        findViewById(R.id.ll_zz_zjbhfy).setOnClickListener(this);
        findViewById(R.id.ll_zz_lxrsf).setOnClickListener(this);
        findViewById(R.id.ll_zz_lxrlxdh).setOnClickListener(this);
        findViewById(R.id.tv_dbcd_nextstep).setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC");
                break;
            case R.id.iv_sczp:
                YMTZ("EditPicture");
                break;
            case R.id.ll_zz_xqmc:
                YMTZ("FB_FC_XQCX");
                break;
            case R.id.ll_zz_mj:
                YMTZ("FB_FC_MJ");
                break;
            case R.id.ll_zz_ts:
                YMTZ("FB_FC_FWQK_TS");
                break;
            case R.id.ll_zz_cx:
                YMTZ("FB_FC_FWQK_CX");
                break;
            case R.id.ll_zz_lc:
                YMTZ("FB_FC_FWQK_LC");
                break;
            case R.id.ll_zz_cw:
                YMTZ("FB_FC_CWDT_CW");
                break;
            case R.id.ll_zz_dt:
                YMTZ("FB_FC_CWDT_DT");
                break;
            case R.id.ll_zz_zj:
                YMTZ("FB_FC_ZJ");
                break;
            case R.id.ll_zz_zjbhfy:
                YMTZ("FB_FC_ZJBHFY");
                break;
            case R.id.ll_zz_lxrsf:
                YMTZ("FB_FC_LXRSF");
                break;
            case R.id.ll_zz_lxrlxdh:
                YMTZ("FB_FC_LXRLXDH");
                break;
            case R.id.tv_dbcd_nextstep:
                YMTZ("NextStep");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC") {
            Intent intent = new Intent(FB_FC_ZZ.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "EditPicture") {
            Intent intent = new Intent(FB_FC_ZZ.this, EditPicture.class);
            startActivity(intent);
        }
        if (id == "FB_FC_XQCX") {
            xqcxWindow = new FB_FC_XQCX(FB_FC_ZZ.this, xqcxOnClick);
            xqcxWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_MJ") {
            mjWindow = new FB_FC_MJ(FB_FC_ZZ.this, mjOnClick);
            mjWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_ZJ") {
            zjWindow = new FB_FC_ZJ(FB_FC_ZZ.this, zjOnClick);
            zjWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_FWQK_TS") {
            fwqkWindow = new FB_FC_FWQK(FB_FC_ZZ.this, fwqkOnClick, "TS");
            fwqkWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwqkWindow.mtvts.setText(mtvts.getText());
            fwqkWindow.mtvcx.setText(mtvcx.getText());
            fwqkWindow.mtvlc.setText(mtvlc.getText());
            fwqkWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            fwqkWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            fwqkWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            fwqkWindow.mwvcx.setWheelItemList(WheelStyle.createCXString());
            fwqkWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            fwqkWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            fwqkWindow.mwvcx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvcx.getText()));
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                fwqkWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                fwqkWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                fwqkWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, 3) + "层"));
            }
        }
        if (id == "FB_FC_FWQK_CX") {
            fwqkWindow = new FB_FC_FWQK(FB_FC_ZZ.this, fwqkOnClick, "CX");
            fwqkWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwqkWindow.mtvts.setText(mtvts.getText());
            fwqkWindow.mtvcx.setText(mtvcx.getText());
            fwqkWindow.mtvlc.setText(mtvlc.getText());
            fwqkWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            fwqkWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            fwqkWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            fwqkWindow.mwvcx.setWheelItemList(WheelStyle.createCXString());
            fwqkWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            fwqkWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            fwqkWindow.mwvcx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvcx.getText()));
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                fwqkWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                fwqkWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                fwqkWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, 3) + "层"));
            }
        }
        if (id == "FB_FC_FWQK_LC") {
            fwqkWindow = new FB_FC_FWQK(FB_FC_ZZ.this, fwqkOnClick, "LC");
            fwqkWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwqkWindow.mtvts.setText(mtvts.getText());
            fwqkWindow.mtvcx.setText(mtvcx.getText());
            fwqkWindow.mtvlc.setText(mtvlc.getText());
            fwqkWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            fwqkWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            fwqkWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            fwqkWindow.mwvcx.setWheelItemList(WheelStyle.createCXString());
            fwqkWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            fwqkWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            fwqkWindow.mwvcx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvcx.getText()));
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                fwqkWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                fwqkWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                fwqkWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, mtvlc.getText().length()) + "层"));
            }
        }
        if (id == "FB_FC_CWDT_CW") {
            cwdtWindow = new FB_FC_CWDT(FB_FC_ZZ.this, cwdtOnClick, "CW");
            cwdtWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            cwdtWindow.mtvcw.setText(mtvcw.getText());
            cwdtWindow.mtvdt.setText(mtvdt.getText());
            cwdtWindow.mwvcw.setWheelItemList(WheelStyle.createCWString());
            cwdtWindow.mwvdt.setWheelItemList(WheelStyle.createDTString());
            cwdtWindow.mwvcw.setCurrentItem(WheelStyle.createCWString().indexOf(mtvcw.getText()));
            cwdtWindow.mwvdt.setCurrentItem(WheelStyle.createDTString().indexOf(mtvdt.getText()));
        }
        if (id == "FB_FC_CWDT_DT") {
            cwdtWindow = new FB_FC_CWDT(FB_FC_ZZ.this, cwdtOnClick, "DT");
            cwdtWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            cwdtWindow.mtvcw.setText(mtvcw.getText());
            cwdtWindow.mtvdt.setText(mtvdt.getText());
            cwdtWindow.mwvcw.setWheelItemList(WheelStyle.createCWString());
            cwdtWindow.mwvdt.setWheelItemList(WheelStyle.createDTString());
            cwdtWindow.mwvcw.setCurrentItem(WheelStyle.createCWString().indexOf(mtvcw.getText()));
            cwdtWindow.mwvdt.setCurrentItem(WheelStyle.createDTString().indexOf(mtvdt.getText()));
        }
        if (id == "FB_FC_ZJBHFY") {
            zjbhfyWindow = new FB_FC_ZJBHFY(FB_FC_ZZ.this, zjbhfyOnClick);
            zjbhfyWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_LXRSF") {
            lxrsfWindow = new FB_FC_LXRSF(FB_FC_ZZ.this, lxrsfOnClick);
            lxrsfWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_LXRLXDH") {
            lxrlxdhWindow = new FB_FC_LXRLXDH(FB_FC_ZZ.this, lxrlxdhOnClick);
            lxrlxdhWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "NextStep") {
            Intent intent = new Intent(FB_FC_ZZ.this, FB_FC_ZZ2.class);
            Bundle bundle = new Bundle();
            bundle.putSerializable("fb_fc_zz", fb_fc_zz);
            intent.putExtras(bundle);
            startActivity(intent);
        }
    }

    //小区查询页面按钮监听
    private View.OnClickListener xqcxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvqx:
                    xqcxWindow.dismiss();
                    break;
                default:
                    xqcxWindow.dismiss();
                    List<View> viewList = Base.getAllChildViews(v);
                    TextView tvxqmc = (TextView)viewList.get(0);
                    mtvxqmc.setText(tvxqmc.getText());

                    fb_fc_zz.XQMC = tvxqmc.getText().toString();
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

                    fb_fc_zz.PFM = mjWindow.metmj.getText().toString();
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
                    mtvyffs.setText(zjWindow.yffs.toString());

                    fb_fc_zz.ZJ = new BigDecimal(zjWindow.metzj.getText().toString().replace("元",""));
                    fb_fc_zz.YFFS = zjWindow.yffs.toString();
                    break;
            }
        }
    };

    //房屋情况页面按钮监听
    private View.OnClickListener fwqkOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_lc_qd:
                    fwqkWindow.dismiss();
                    mtvts.setText(fwqkWindow.mtvts.getText());
                    mtvcx.setText(fwqkWindow.mtvcx.getText());
                    mtvlc.setText(WheelStyle.createCString().get(fwqkWindow.mwvc.getCurrentItem()).replace("层","") + "/" + WheelStyle.createGJCString().get(fwqkWindow.mwvgjc.getCurrentItem()).replace("共","").replace("层",""));

                    fb_fc_zz.S = WheelStyle.createSString().get(fwqkWindow.mwvs.getCurrentItem());
                    fb_fc_zz.T = WheelStyle.createTString().get(fwqkWindow.mwvt.getCurrentItem());
                    fb_fc_zz.W = WheelStyle.createWString().get(fwqkWindow.mwvw.getCurrentItem());
                    fb_fc_zz.CX = fwqkWindow.mtvcx.getText().toString();
                    fb_fc_zz.C = WheelStyle.createCString().get(fwqkWindow.mwvc.getCurrentItem()).replace("层","");
                    fb_fc_zz.GJC = WheelStyle.createGJCString().get(fwqkWindow.mwvc.getCurrentItem()).replace("层","");
                    break;
            }
        }
    };

    //车位电梯页面按钮监听
    private View.OnClickListener cwdtOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_dt_qd:
                    cwdtWindow.dismiss();
                    mtvcw.setText(WheelStyle.createCWString().get(cwdtWindow.mwvcw.getCurrentItem()));
                    mtvdt.setText(WheelStyle.createDTString().get(cwdtWindow.mwvdt.getCurrentItem()));
                    break;
            }
        }
    };

    //租金包含费用页面按钮监听
    private View.OnClickListener zjbhfyOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    zjbhfyWindow.dismiss();
                    mtvzjbhfy.setText(zjbhfyWindow.GetCheck());

                    fb_fc_zz.ZJYBHFY = zjbhfyWindow.GetCheck();
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

                    fb_fc_zz.LXDH = lxrlxdhWindow.metLXDH.getText().toString();
                    break;
            }
        }
    };
}
