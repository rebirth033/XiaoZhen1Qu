package FBXX.FC;

import com.example.administrator.Public.R;
import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.PopupWindow;
import android.widget.TextView;
import java.util.ArrayList;
import java.util.List;

public class FB_FC_ESF_CQZX extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllcqnx; //产权年限
    private ViewGroup mllcqlx; //产权类型
    private ViewGroup mllzxqk; //装修情况
    public TextView mtvcqnx; //产权年限
    public TextView mtvcqlx; //产权类型
    public TextView mtvzxqk; //装修情况
    private TabLayout.Tab tabcqnx; //产权年限
    private TabLayout.Tab tabcqlx; //产权类型
    private TabLayout.Tab tabzxqk; //装修情况
    private TextView mtvcqnxqd; //产权年限
    private TextView mtvcqlxqd; //产权类型
    private TextView mtvzxqkqd; //装修情况
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvcqnx;//产权年限
    public WheelView mwvcqlx;//产权类型
    public WheelView mwvzxqk;//装修情况

    public FB_FC_ESF_CQZX(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_esf_cqzx, null);
        //设置SelectPicPopupWindow的View
        this.setContentView(mMenuView);
        //设置SelectPicPopupWindow弹出窗体的宽
        this.setWidth(ViewGroup.LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体的高
        this.setHeight(ViewGroup.LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体可点击
        this.setFocusable(true);
        //设置SelectPicPopupWindow弹出窗体动画效果
        this.setAnimationStyle(R.style.AnimBottom);
        //实例化一个ColorDrawable颜色为半透明
        ColorDrawable dw = new ColorDrawable(0xb0000000);
        //设置SelectPicPopupWindow弹出窗体的背景
        this.setBackgroundDrawable(dw);
        //初始化页面
        initView(itemsOnClick,context, type);
    }

    //初始化页面
    private void initView(View.OnClickListener itemsOnClick, Activity context, String type) {

        mtvcqnx = (TextView) mMenuView.findViewById(R.id.tv_fwqk_cqnx);
        mtvcqlx = (TextView) mMenuView.findViewById(R.id.tv_fwqk_cqlx);
        mtvzxqk = (TextView) mMenuView.findViewById(R.id.tv_fwqk_zxqk);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllcqnx = (ViewGroup)mMenuView.findViewById(R.id.ll_fwqk_cqnx);
        mllcqlx = (ViewGroup)mMenuView.findViewById(R.id.ll_fwqk_cqlx);
        mllzxqk = (ViewGroup)mMenuView.findViewById(R.id.ll_fwqk_zxqk);

        mllcqnx.setOnClickListener(this);
        mllcqlx.setOnClickListener(this);
        mllzxqk.setOnClickListener(this);

        tabcqnx = mtbbody.newTab().setCustomView(mllcqnx);
        tabcqlx = mtbbody.newTab().setCustomView(mllcqlx);
        tabzxqk = mtbbody.newTab().setCustomView(mllzxqk);
        mtbbody.addTab(tabcqnx);
        mtbbody.addTab(tabcqlx);
        mtbbody.addTab(tabzxqk);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vts = inflater.inflate(R.layout.fragment_cqnx, null);
        View vcx = inflater.inflate(R.layout.fragment_cqlx, null);
        View vlc = inflater.inflate(R.layout.fragment_zxqk, null);
        viewList.add(vts);
        viewList.add(vcx);
        viewList.add(vlc);

        mwvcqnx = (WheelView) vts.findViewById(R.id.wvcqnx);
        mwvcqlx = (WheelView) vcx.findViewById(R.id.wvcqlx);
        mwvzxqk = (WheelView) vlc.findViewById(R.id.wvzxqk);

        mtvcqnxqd = (TextView) vts.findViewById(R.id.tv_cqnx_qd);
        mtvcqlxqd = (TextView) vcx.findViewById(R.id.tv_cqlx_qd);
        mtvzxqkqd = (TextView) vlc.findViewById(R.id.tv_zxqk_qd);

        mtvcqnxqd.setOnClickListener(this);
        mtvcqlxqd.setOnClickListener(this);
        mtvzxqkqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "CQNX")
            mllcqnx.performClick();
        if(type == "CQLX")
            mllcqlx.performClick();
        if(type == "ZXQK")
            mllzxqk.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_fwqk_cqnx:
                mtvcqnx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvcqnx.setTextColor(Color.parseColor("#bc6ba6"));
                mtvcqlx.setHintTextColor(Color.parseColor("#999999"));
                mtvcqlx.setTextColor(Color.parseColor("#000000"));
                mtvzxqk.setHintTextColor(Color.parseColor("#999999"));
                mtvzxqk.setTextColor(Color.parseColor("#000000"));
                tabcqnx.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.ll_fwqk_cqlx:
                mtvcqnx.setHintTextColor(Color.parseColor("#999999"));
                mtvcqnx.setTextColor(Color.parseColor("#000000"));
                mtvcqlx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvcqlx.setTextColor(Color.parseColor("#bc6ba6"));
                mtvzxqk.setHintTextColor(Color.parseColor("#999999"));
                mtvzxqk.setTextColor(Color.parseColor("#000000"));
                tabcqlx.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.ll_fwqk_zxqk:
                mtvcqnx.setHintTextColor(Color.parseColor("#999999"));
                mtvcqnx.setTextColor(Color.parseColor("#000000"));
                mtvcqlx.setHintTextColor(Color.parseColor("#999999"));
                mtvcqlx.setTextColor(Color.parseColor("#000000"));
                mtvzxqk.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvzxqk.setTextColor(Color.parseColor("#bc6ba6"));
                tabzxqk.select();
                mvpbody.setCurrentItem(2);
                break;
            case R.id.tv_cqnx_qd:
                mtvcqnx.setText(WheelStyle.createCQNXString().get(mwvcqnx.getCurrentItem()));
                mllcqlx.performClick();
                break;
            case R.id.tv_cqlx_qd:
                mtvcqlx.setText(WheelStyle.createCQLXString().get(mwvcqlx.getCurrentItem()));
                mllzxqk.performClick();
                break;
            case R.id.tv_zxqk_qd:
                mtvzxqk.setText(WheelStyle.createZXQKString().get(mwvzxqk.getCurrentItem()));
                mllcqnx.performClick();
                break;
        }
    }
}
