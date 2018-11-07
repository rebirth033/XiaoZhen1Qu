package FBXX.FC;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import com.example.administrator.Public.R;
import java.util.List;
import COMMON.Base;
import COMMON.EditPicture;
import COMMON.SelectPicture;
import LBXZ.FB_FC;

public class FB_FC_ZZ extends Base implements View.OnClickListener {

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
        ImageView mivback = (ImageView) findViewById(R.id.iv_back);
        ImageView mivsczp = (ImageView) findViewById(R.id.iv_sczp);
        ViewGroup mllxq = (ViewGroup) findViewById(R.id.ll_zz_xqmc);
        ViewGroup mllmj = (ViewGroup) findViewById(R.id.ll_zz_mj);
        ViewGroup mllts = (ViewGroup) findViewById(R.id.ll_zz_ts);
        ViewGroup mllcx = (ViewGroup) findViewById(R.id.ll_zz_cx);
        ViewGroup mlllc = (ViewGroup) findViewById(R.id.ll_zz_lc);
        ViewGroup mllcw = (ViewGroup) findViewById(R.id.ll_zz_cw);
        ViewGroup mlldt = (ViewGroup) findViewById(R.id.ll_zz_dt);
        ViewGroup mllzj = (ViewGroup) findViewById(R.id.ll_zz_zj);
        ViewGroup mllzjbhfy = (ViewGroup) findViewById(R.id.ll_zz_zjbhfy);
        ViewGroup mlllxrsf = (ViewGroup) findViewById(R.id.ll_zz_lxrsf);
        ViewGroup mlllxrlxdh = (ViewGroup) findViewById(R.id.ll_zz_lxrlxdh);
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
        mivback.setOnClickListener(this);
        mivsczp.setOnClickListener(this);
        mllxq.setOnClickListener(this);
        mllmj.setOnClickListener(this);
        mllts.setOnClickListener(this);
        mllcx.setOnClickListener(this);
        mlllc.setOnClickListener(this);
        mllcw.setOnClickListener(this);
        mlldt.setOnClickListener(this);
        mllzj.setOnClickListener(this);
        mllzjbhfy.setOnClickListener(this);
        mlllxrsf.setOnClickListener(this);
        mlllxrlxdh.setOnClickListener(this);
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
                YMTZ("FB_FC_FWQK");
                break;
            case R.id.ll_zz_cx:
                YMTZ("FB_FC_FWQK");
                break;
            case R.id.ll_zz_lc:
                YMTZ("FB_FC_FWQK");
                break;
            case R.id.ll_zz_cw:
                YMTZ("FB_FC_CWDT");
                break;
            case R.id.ll_zz_dt:
                YMTZ("FB_FC_CWDT");
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
        if (id == "FB_FC_FWQK") {
            fwqkWindow = new FB_FC_FWQK(FB_FC_ZZ.this, fwqkOnClick);
            fwqkWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwqkWindow.mtvts.setText(mtvts.getText());
            fwqkWindow.mtvcx.setText(mtvcx.getText());
            fwqkWindow.mtvlc.setText(mtvlc.getText());
        }
        if (id == "FB_FC_CWDT") {
            cwdtWindow = new FB_FC_CWDT(FB_FC_ZZ.this, cwdtOnClick);
            cwdtWindow.showAtLocation(FB_FC_ZZ.this.findViewById(R.id.fb_fc_zz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
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
                    mtvmj.setText(mjWindow.metMJ.getText());
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
                    mtvzj.setText(zjWindow.metZJ.getText());
                    mtvyffs.setText(zjWindow.yffs.toString());
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
                    break;
            }
        }
    };
}
