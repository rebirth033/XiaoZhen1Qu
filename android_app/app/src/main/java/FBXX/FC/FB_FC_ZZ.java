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
import LBXZ.FB_FC;

public class FB_FC_ZZ extends Base implements View.OnClickListener {

    private TextView mtvxqmc;
    private TextView mtvmj;
    private TextView mtvzj;
    private TextView mtvts;
    private TextView mtvcx;
    private TextView mtvlc;
    private TextView mtvcw;
    private TextView mtvdt;
    private TextView mtvyffs;
    private TextView mtvzjbhfy;
    private TextView mtvlxrsf;
    private TextView mtvlxrlxdh;
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
        findById();
        String XQMC = intent.getStringExtra("XQMC");
        String YMMC = intent.getStringExtra("YMMC");
        if(YMMC.equalsIgnoreCase("FB_FC_XQCX"))
            mtvxqmc.setText(XQMC);
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
                case R.id.ivqx:
                    fwqkWindow.dismiss();
                    break;
                case R.id.tvqd:
                    fwqkWindow.dismiss();
                    mtvmj.setText(mjWindow.metMJ.getText());
                    break;
            }
        }
    };

    //车位电梯页面按钮监听
    private View.OnClickListener cwdtOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    cwdtWindow.dismiss();
                    break;
                case R.id.tvqd:
                    cwdtWindow.dismiss();
                    mtvmj.setText(mjWindow.metMJ.getText());
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

    private void findById() {
        ImageView ivBack = (ImageView) findViewById(R.id.ivBACK);
        ViewGroup mllxq = (ViewGroup) findViewById(R.id.ll_xq);
        ViewGroup mllmj = (ViewGroup) findViewById(R.id.ll_mj);
        ViewGroup mllts = (ViewGroup) findViewById(R.id.ll_ts);
        ViewGroup mllcx = (ViewGroup) findViewById(R.id.ll_cx);
        ViewGroup mlllc = (ViewGroup) findViewById(R.id.ll_lc);
        ViewGroup mllcw = (ViewGroup) findViewById(R.id.ll_cw);
        ViewGroup mlldt = (ViewGroup) findViewById(R.id.ll_dt);
        ViewGroup mllzj = (ViewGroup) findViewById(R.id.ll_zj);
        ViewGroup mllzjbhfy = (ViewGroup) findViewById(R.id.ll_zjbhfy);
        ViewGroup mlllxrsf = (ViewGroup) findViewById(R.id.ll_lxrsf);
        ViewGroup mlllxrlxdh = (ViewGroup) findViewById(R.id.ll_lxrlxdh);
        mtvxqmc = (TextView) findViewById(R.id.tv_xqmc);
        mtvmj = (TextView) findViewById(R.id.tv_mj);
        mtvts = (TextView) findViewById(R.id.tv_ts);
        mtvcx= (TextView) findViewById(R.id.tv_cx);
        mtvlc = (TextView) findViewById(R.id.tv_lc);
        mtvcw = (TextView) findViewById(R.id.tv_cw);
        mtvdt = (TextView) findViewById(R.id.tv_dt);
        mtvzj = (TextView) findViewById(R.id.tv_zj);
        mtvyffs = (TextView) findViewById(R.id.tv_yffs);
        mtvzjbhfy = (TextView) findViewById(R.id.tv_zjbhfy);
        mtvlxrsf = (TextView) findViewById(R.id.tv_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_lxrlxdh);
        ivBack.setOnClickListener(this);
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
            case R.id.ivBACK:
                YMTZ("FB_FC");
                break;
            case R.id.ll_xq:
                YMTZ("FB_FC_XQCX");
                break;
            case R.id.ll_mj:
                YMTZ("FB_FC_MJ");
                break;
            case R.id.ll_ts:
                YMTZ("FB_FC_FWQK");
                break;
            case R.id.ll_cx:
                YMTZ("FB_FC_FWQK");
                break;
            case R.id.ll_lc:
                YMTZ("FB_FC_FWQK");
                break;
            case R.id.ll_cw:
                YMTZ("FB_FC_CWDT");
                break;
            case R.id.ll_dt:
                YMTZ("FB_FC_CWDT");
                break;
            case R.id.ll_zj:
                YMTZ("FB_FC_ZJ");
                break;
            case R.id.ll_zjbhfy:
                YMTZ("FB_FC_ZJBHFY");
                break;
            case R.id.ll_lxrsf:
                YMTZ("FB_FC_LXRSF");
                break;
            case R.id.ll_lxrlxdh:
                YMTZ("FB_FC_LXRLXDH");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "FB_FC") {
            Intent intent = new Intent(FB_FC_ZZ.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
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
}
