package FBXX.FC;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;
import com.example.administrator.Public.R;
import Common.Base;
import Entities.FC_SP_Model;

public class FB_FC_SP_CS2 extends Base implements View.OnClickListener {

    public FC_SP_Model fb_fc_sp = new FC_SP_Model();
    private LinearLayout mllSPPT;
    public TextView mtvwyf;
    public TextView mtvsf;
    public TextView mtvdf;

    FB_FC_SP_WYFSFDF wyfsfdfWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_sp_cs2);
        initView();
        loadSPPT();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_sp_wyf).setOnClickListener(this);
        findViewById(R.id.ll_sp_sf).setOnClickListener(this);
        findViewById(R.id.ll_sp_df).setOnClickListener(this);
        findViewById(R.id.ll_sp_szqy).setOnClickListener(this);
        findViewById(R.id.ll_sp_spdz).setOnClickListener(this);

        mtvwyf = (TextView) findViewById(R.id.tv_sp_wyf);
        mtvsf = (TextView) findViewById(R.id.tv_sp_sf);
        mtvdf = (TextView) findViewById(R.id.tv_sp_df);

        mllSPPT = (LinearLayout)findViewById(R.id.ll_sp_sppt);
        mllSPPT.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC_SP_CS");
                break;
            case R.id.ll_sp_wyf:
                YMTZ("FB_FC_SP_WYF");
                break;
            case R.id.ll_sp_sf:
                YMTZ("FB_FC_SP_SF");
                break;
            case R.id.ll_sp_df:
                YMTZ("FB_FC_SP_DF");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC_SP_CS") {
            Intent intent = new Intent(FB_FC_SP_CS2.this, FB_FC_SP_CS.class);
            startActivity(intent);
        }
        if (id == "FB_FC_SP_WYF") {
            wyfsfdfWindow = new FB_FC_SP_WYFSFDF(FB_FC_SP_CS2.this, wyfsfdfOnClick, "wyf");
            wyfsfdfWindow.showAtLocation(FB_FC_SP_CS2.this.findViewById(R.id.fb_fc_sp_cs2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            wyfsfdfWindow.mtvwyf.setText(mtvwyf.getText());
            wyfsfdfWindow.mtvsf.setText(mtvsf.getText());
            wyfsfdfWindow.mtvdf.setText(mtvdf.getText());
        }
        if (id == "FB_FC_SP_SF") {
            wyfsfdfWindow = new FB_FC_SP_WYFSFDF(FB_FC_SP_CS2.this, wyfsfdfOnClick, "sf");
            wyfsfdfWindow.showAtLocation(FB_FC_SP_CS2.this.findViewById(R.id.fb_fc_sp_cs2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            wyfsfdfWindow.mtvwyf.setText(mtvwyf.getText());
            wyfsfdfWindow.mtvsf.setText(mtvsf.getText());
            wyfsfdfWindow.mtvdf.setText(mtvdf.getText());
        }
        if (id == "FB_FC_SP_DF") {
            wyfsfdfWindow = new FB_FC_SP_WYFSFDF(FB_FC_SP_CS2.this, wyfsfdfOnClick, "df");
            wyfsfdfWindow.showAtLocation(FB_FC_SP_CS2.this.findViewById(R.id.fb_fc_sp_cs2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            wyfsfdfWindow.mtvwyf.setText(mtvwyf.getText());
            wyfsfdfWindow.mtvsf.setText(mtvsf.getText());
            wyfsfdfWindow.mtvdf.setText(mtvdf.getText());
        }
    }
    //物业费水费电费页面按钮监听
    private View.OnClickListener wyfsfdfOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    wyfsfdfWindow.dismiss();
                    break;
                case R.id.tv_df_qd:
                    wyfsfdfWindow.dismiss();
                    mtvwyf.setText(wyfsfdfWindow.mtvwyf.getText());
                    mtvsf.setText(wyfsfdfWindow.mtvsf.getText());
                    mtvdf.setText(wyfsfdfWindow.mtvdf.getText());

                    fb_fc_sp.WYF = wyfsfdfWindow.mtvwyf.getText().toString();
                    fb_fc_sp.SHUIF = wyfsfdfWindow.mtvsf.getText().toString();
                    fb_fc_sp.DF = wyfsfdfWindow.mtvdf.getText().toString();
                    break;
            }
        }
    };

    //加载商铺配套
    public void loadSPPT(){
        String fwpzs0 = "客梯,货梯,中央空调,停车位";
        String fwpzs1 = "天然气,电话/网络,暖气,扶梯";
        String fwpzs2 = "上水,下水,排烟,排污";
        String[] fwpzlist = new String[3];
        fwpzlist[0] = fwpzs0;
        fwpzlist[1] = fwpzs1;
        fwpzlist[2] = fwpzs2;

        for(int j = 0; j < 3; j++) {
            LinearLayout llouter = new LinearLayout(this);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 240);
            llouter.setLayoutParams(layoutParams);
            llouter.setOrientation(LinearLayout.HORIZONTAL);

            for (int i = 0; i < fwpzlist[j].split(",").length; i++) {
                TextView tvmc = new TextView(this);
                layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
                layoutParams.setMargins(10, 0, 0, 0);
                tvmc.setLayoutParams(layoutParams);
                tvmc.setPadding(10, 7, 10, 7);
                tvmc.setTextSize(16);
                tvmc.setTextColor(Color.parseColor("#666666"));
                tvmc.setText(fwpzlist[j].split(",")[i]);
                tvmc.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                tvmc.setTag(R.drawable.radius_unselect);
                tvmc.setOnClickListener(new View.OnClickListener(){
                    public void onClick(View v) {
                        TextView tv = (TextView)v;
                        int res = (int) tv.getTag();
                        if(res == R.drawable.radius_select) {
                            tv.setTextColor(Color.parseColor("#666666"));
                            tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                            tv.setTag(R.drawable.radius_unselect);
                        }
                        else{
                            tv.setTextColor(Color.parseColor("#ffffff"));
                            tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_select));
                            tv.setTag(R.drawable.radius_select);
                        }
                    }
                });
                llouter.addView(tvmc);
            }
            mllSPPT.addView(llouter);
        }
    }
}
