package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.math.BigDecimal;
import java.util.List;
import Common.Base;
import Common.EditPicture;
import Common.WheelStyle;
import Entities.FC_HZF_Model;
import LBXZ.FB_FC;

public class FB_FC_HZ extends Base implements View.OnClickListener {

    public FC_HZF_Model FB_FC_HZ = new FC_HZF_Model();
    public TextView mtvxqmc;
    public TextView mtvmj;
    public TextView mtvzj;
    public TextView mtvts;
    public TextView mtvlc;
    public TextView mtvwslx;
    public TextView mtvwscx;
    public TextView mtvyffs;
    public TextView mtvzjbhfy;
    public TextView mtvlxrsf;
    public TextView mtvlxrlxdh;
    //自定义的弹出框类
    FB_FC_XQCX xqcxWindow;
    FB_FC_MJ mjWindow;
    FB_FC_ZJ zjWindow;
    FB_FC_HXLC hxlcWindow;
    FB_FC_LXCX lxcxWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_hz);
        Intent intent = getIntent();
        initView();
        String XQMC = intent.getStringExtra("XQMC");
        String YMMC = intent.getStringExtra("YMMC");
        if(YMMC.equalsIgnoreCase("FB_FC_XQCX"))
            mtvxqmc.setText(XQMC);
    }

    //初始化页面
    private void initView() {
        ImageView mivback = (ImageView) findViewById(R.id.iv_back);
        ImageView mivsczp = (ImageView) findViewById(R.id.iv_sczp);
        ViewGroup mllxq = (ViewGroup) findViewById(R.id.ll_hz_xqmc);
        ViewGroup mllts = (ViewGroup) findViewById(R.id.ll_hz_ts);
        ViewGroup mlllc = (ViewGroup) findViewById(R.id.ll_hz_lc);
        ViewGroup mllwslx = (ViewGroup) findViewById(R.id.ll_hz_wslx);
        ViewGroup mllwscx = (ViewGroup) findViewById(R.id.ll_hz_wscx);
        ViewGroup mllmj = (ViewGroup) findViewById(R.id.ll_hz_mj);
        ViewGroup mllzj = (ViewGroup) findViewById(R.id.ll_hz_zj);
        TextView mtvnext = (TextView) findViewById(R.id.tv_dbcd_nextstep);
        mtvxqmc = (TextView) findViewById(R.id.tv_hz_xqmc);
        mtvts = (TextView) findViewById(R.id.tv_hz_ts);
        mtvlc = (TextView) findViewById(R.id.tv_hz_lc);
        mtvwslx = (TextView) findViewById(R.id.tv_hz_wslx);
        mtvwscx = (TextView) findViewById(R.id.tv_hz_wscx);
        mtvmj = (TextView) findViewById(R.id.tv_hz_mj);
        mtvzj = (TextView) findViewById(R.id.tv_hz_zj);
        mtvyffs = (TextView) findViewById(R.id.tv_hz_yffs);
        mivback.setOnClickListener(this);
        mivsczp.setOnClickListener(this);
        mllxq.setOnClickListener(this);
        mllmj.setOnClickListener(this);
        mllzj.setOnClickListener(this);
        mllts.setOnClickListener(this);
        mlllc.setOnClickListener(this);
        mllwslx.setOnClickListener(this);
        mllwscx.setOnClickListener(this);
        mtvnext.setOnClickListener(this);
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
            case R.id.ll_hz_xqmc:
                YMTZ("FB_FC_XQCX");
                break;
            case R.id.ll_hz_mj:
                YMTZ("FB_FC_MJ");
                break;
            case R.id.ll_hz_zj:
                YMTZ("FB_FC_ZJ");
                break;
            case R.id.ll_hz_ts:
                YMTZ("FB_FC_FWQK_TS");
                break;
            case R.id.ll_hz_lc:
                YMTZ("FB_FC_FWQK_LC");
                break;
            case R.id.ll_hz_wslx:
                YMTZ("FB_FC_LXCX_LX");
                break;
            case R.id.ll_hz_wscx:
                YMTZ("FB_FC_LXCX_CX");
                break;
            case R.id.tv_dbcd_nextstep:
                YMTZ("FB_FC_HZ2");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC") {
            Intent intent = new Intent(FB_FC_HZ.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "EditPicture") {
            Intent intent = new Intent(FB_FC_HZ.this, EditPicture.class);
            startActivity(intent);
        }
        if (id == "FB_FC_XQCX") {
            xqcxWindow = new FB_FC_XQCX(FB_FC_HZ.this, xqcxOnClick);
            xqcxWindow.showAtLocation(FB_FC_HZ.this.findViewById(R.id.fb_fc_hz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_MJ") {
            mjWindow = new FB_FC_MJ(FB_FC_HZ.this, mjOnClick);
            mjWindow.showAtLocation(FB_FC_HZ.this.findViewById(R.id.fb_fc_hz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            mjWindow.metmj.setText(mtvmj.getText());
        }
        if (id == "FB_FC_ZJ") {
            zjWindow = new FB_FC_ZJ(FB_FC_HZ.this, zjOnClick);
            zjWindow.showAtLocation(FB_FC_HZ.this.findViewById(R.id.fb_fc_hz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            zjWindow.metzj.setText(mtvzj.getText());
        }
        if (id == "FB_FC_FWQK_TS") {
            hxlcWindow = new FB_FC_HXLC(FB_FC_HZ.this, hxlcOnClick, "TS");
            hxlcWindow.showAtLocation(FB_FC_HZ.this.findViewById(R.id.fb_fc_hz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            hxlcWindow.mtvts.setText(mtvts.getText());
            hxlcWindow.mtvlc.setText(mtvlc.getText());
            hxlcWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            hxlcWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            hxlcWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            hxlcWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            hxlcWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                hxlcWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                hxlcWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                hxlcWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                hxlcWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                hxlcWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, 3) + "层"));
            }
        }
        if (id == "FB_FC_FWQK_LC") {
            hxlcWindow = new FB_FC_HXLC(FB_FC_HZ.this, hxlcOnClick, "LC");
            hxlcWindow.showAtLocation(FB_FC_HZ.this.findViewById(R.id.fb_fc_hz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            hxlcWindow.mtvts.setText(mtvts.getText());
            hxlcWindow.mtvlc.setText(mtvlc.getText());
            hxlcWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            hxlcWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            hxlcWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            hxlcWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            hxlcWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                hxlcWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                hxlcWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                hxlcWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                hxlcWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                hxlcWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, mtvlc.getText().length()) + "层"));
            }
        }
        if (id == "FB_FC_LXCX_LX") {
            lxcxWindow = new FB_FC_LXCX(FB_FC_HZ.this, lxcxOnClick, "CW");
            lxcxWindow.showAtLocation(FB_FC_HZ.this.findViewById(R.id.fb_fc_hz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            lxcxWindow.mtvwslx.setText(mtvwslx.getText());
            lxcxWindow.mtvwscx.setText(mtvwscx.getText());
            lxcxWindow.mwvwslx.setWheelItemList(WheelStyle.createWSLXString());
            lxcxWindow.mwvwscx.setWheelItemList(WheelStyle.createCXString());
            lxcxWindow.mwvwslx.setCurrentItem(WheelStyle.createWSLXString().indexOf(mtvwslx.getText()));
            lxcxWindow.mwvwscx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvwscx.getText()));
        }
        if (id == "FB_FC_LXCX_CX") {
            lxcxWindow = new FB_FC_LXCX(FB_FC_HZ.this, lxcxOnClick, "DT");
            lxcxWindow.showAtLocation(FB_FC_HZ.this.findViewById(R.id.fb_fc_hz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            lxcxWindow.mtvwslx.setText(mtvwslx.getText());
            lxcxWindow.mtvwscx.setText(mtvwscx.getText());
            lxcxWindow.mwvwslx.setWheelItemList(WheelStyle.createWSLXString());
            lxcxWindow.mwvwscx.setWheelItemList(WheelStyle.createCXString());
            lxcxWindow.mwvwslx.setCurrentItem(WheelStyle.createWSLXString().indexOf(mtvwslx.getText()));
            lxcxWindow.mwvwscx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvwscx.getText()));
        }
        if (id == "FB_FC_HZ2") {
            Intent intent = new Intent(FB_FC_HZ.this, FB_FC_HZ2.class);
            Bundle bundle = new Bundle();
            bundle.putSerializable("FB_FC_HZ", FB_FC_HZ);
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

                    FB_FC_HZ.XQMC = tvxqmc.getText().toString();
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

                    FB_FC_HZ.PFM = mjWindow.metmj.getText().toString();
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

                    FB_FC_HZ.ZJ = new BigDecimal(zjWindow.metzj.getText().toString().replace("元",""));
                    break;
            }
        }
    };

    //房屋情况页面按钮监听
    private View.OnClickListener hxlcOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_lc_qd:
                    hxlcWindow.dismiss();
                    mtvts.setText(hxlcWindow.mtvts.getText());
                    mtvlc.setText(WheelStyle.createCString().get(hxlcWindow.mwvc.getCurrentItem()).replace("层","") + "/" + WheelStyle.createGJCString().get(hxlcWindow.mwvgjc.getCurrentItem()).replace("共","").replace("层",""));

                    FB_FC_HZ.S = WheelStyle.createSString().get(hxlcWindow.mwvs.getCurrentItem());
                    FB_FC_HZ.T = WheelStyle.createTString().get(hxlcWindow.mwvt.getCurrentItem());
                    FB_FC_HZ.W = WheelStyle.createWString().get(hxlcWindow.mwvw.getCurrentItem());
                    FB_FC_HZ.C = WheelStyle.createCString().get(hxlcWindow.mwvc.getCurrentItem()).replace("层","");
                    FB_FC_HZ.GJC = WheelStyle.createGJCString().get(hxlcWindow.mwvc.getCurrentItem()).replace("层","");
                    break;
            }
        }
    };

    //类型朝向页面按钮监听
    private View.OnClickListener lxcxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_cx_qd:
                    lxcxWindow.dismiss();
                    mtvwslx.setText(WheelStyle.createWSLXString().get(lxcxWindow.mwvwslx.getCurrentItem()));
                    mtvwscx.setText(WheelStyle.createCXString().get(lxcxWindow.mwvwscx.getCurrentItem()));
                    break;
            }
        }
    };
}
