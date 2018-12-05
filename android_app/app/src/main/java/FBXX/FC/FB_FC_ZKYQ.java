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

import Common.ViewAdapter;
import Common.WheelStyle;
import Common.WheelView;

public class FB_FC_ZKYQ extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllkfsj; //看房时间
    private ViewGroup mllzkxb; //租客性别
    private ViewGroup mllrzsj; //入住时间
    public TextView mtvkfsj; //看房时间
    public TextView mtvzkxb; //租客性别
    public TextView mtvrzsj; //入住时间
    private TabLayout.Tab tabkfsj; //看房时间
    private TabLayout.Tab tabzkxb; //租客性别
    private TabLayout.Tab tabrzsj; //入住时间
    public TextView mtvkfsjqd;//看房时间_确定按钮
    public TextView mtvzkxbqd;//租客性别_确定按钮
    public TextView mtvrzsjqd;//入住时间_确定按钮
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvkfsj;//看房时间
    public WheelView mwvzkxb;//租客性别
    public WheelView mwvyear;//年
    public WheelView mwvmonth;//月
    public WheelView mwvday;//日

    public FB_FC_ZKYQ(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_zkyq, null);
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
        initView(itemsOnClick, context, type);
    }

    private void initView(View.OnClickListener itemsOnClick, Activity context, String type) {

        mllkfsj = (ViewGroup) mMenuView.findViewById(R.id.ll_rzxx_kfsj);
        mllzkxb = (ViewGroup) mMenuView.findViewById(R.id.ll_rzxx_zkxb);
        mllrzsj = (ViewGroup) mMenuView.findViewById(R.id.ll_rzxx_rzsj);
        mtvkfsj = (TextView) mMenuView.findViewById(R.id.tv_rzxx_kfsj);
        mtvzkxb = (TextView) mMenuView.findViewById(R.id.tv_rzxx_zkxb);
        mtvrzsj = (TextView) mMenuView.findViewById(R.id.tv_rzxx_rzsj);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllkfsj.setOnClickListener(this);
        mllzkxb.setOnClickListener(this);
        mllrzsj.setOnClickListener(this);

        tabkfsj = mtbbody.newTab().setCustomView(mllkfsj);
        tabzkxb = mtbbody.newTab().setCustomView(mllzkxb);
        tabrzsj = mtbbody.newTab().setCustomView(mllrzsj);
        mtbbody.addTab(tabkfsj);
        mtbbody.addTab(tabzkxb);
        mtbbody.addTab(tabrzsj);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vkfsj = inflater.inflate(R.layout.fragment_kfsj, null);
        View vzkxb = inflater.inflate(R.layout.fragment_zkxb, null);
        View vrzsj = inflater.inflate(R.layout.fragment_rzsj, null);
        viewList.add(vkfsj);
        viewList.add(vzkxb);
        viewList.add(vrzsj);

        mwvkfsj = (WheelView) vkfsj.findViewById(R.id.wvkfsj);
        mwvzkxb = (WheelView) vzkxb.findViewById(R.id.wvzkxb);
        mwvyear = (WheelView) vrzsj.findViewById(R.id.wvyear);
        mwvmonth = (WheelView) vrzsj.findViewById(R.id.wvmonth);
        mwvday = (WheelView) vrzsj.findViewById(R.id.wvday);

        mtvkfsjqd = (TextView) vkfsj.findViewById(R.id.tv_kfsj_qd);
        mtvzkxbqd = (TextView) vzkxb.findViewById(R.id.tv_zkxb_qd);
        mtvrzsjqd = (TextView) vrzsj.findViewById(R.id.tv_rzsj_qd);
        mtvkfsjqd.setOnClickListener(this);
        mtvzkxbqd.setOnClickListener(this);
        mtvrzsjqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "KFSJ")
            mllkfsj.performClick();
        if(type == "ZKXB")
            mllzkxb.performClick();
        if(type == "RZSJ")
            mllrzsj.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_rzxx_kfsj:
                mtvkfsj.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvkfsj.setTextColor(Color.parseColor("#bc6ba6"));
                mtvzkxb.setHintTextColor(Color.parseColor("#999999"));
                mtvzkxb.setTextColor(Color.parseColor("#000000"));
                mtvrzsj.setHintTextColor(Color.parseColor("#999999"));
                mtvrzsj.setTextColor(Color.parseColor("#000000"));
                tabkfsj.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.ll_rzxx_zkxb:
                mtvkfsj.setHintTextColor(Color.parseColor("#999999"));
                mtvkfsj.setTextColor(Color.parseColor("#000000"));
                mtvzkxb.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvzkxb.setTextColor(Color.parseColor("#bc6ba6"));
                mtvrzsj.setHintTextColor(Color.parseColor("#999999"));
                mtvrzsj.setTextColor(Color.parseColor("#000000"));
                tabzkxb.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.ll_rzxx_rzsj:
                mtvkfsj.setHintTextColor(Color.parseColor("#999999"));
                mtvkfsj.setTextColor(Color.parseColor("#000000"));
                mtvzkxb.setHintTextColor(Color.parseColor("#999999"));
                mtvzkxb.setTextColor(Color.parseColor("#000000"));
                mtvrzsj.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvrzsj.setTextColor(Color.parseColor("#bc6ba6"));
                tabrzsj.select();
                mvpbody.setCurrentItem(2);
                break;
            case R.id.tv_kfsj_qd:
                mtvkfsj.setText(WheelStyle.createKFSJString().get(mwvkfsj.getCurrentItem()));
                mllzkxb.performClick();
                break;
            case R.id.tv_zkxb_qd:
                mtvzkxb.setText(WheelStyle.createZKXBString().get(mwvzkxb.getCurrentItem()));
                mllrzsj.performClick();
                break;
        }
    }
}
