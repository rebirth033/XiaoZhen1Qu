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

public class FB_FC_ESF_LXGN extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllfwlx; //房屋类型
    private ViewGroup mllgnlx; //供暖类型
    public TextView mtvfwlx; //房屋类型
    public TextView mtvgnlx; //供暖类型
    private TabLayout.Tab tabfwlx; //房屋类型
    private TabLayout.Tab tabgnlx; //供暖类型
    private TextView mtvlxqd; //房屋类型
    private TextView mtvgnlxqd; //供暖类型
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvfwlx;//房屋类型
    public WheelView mwvgnlx;//供暖类型

    public FB_FC_ESF_LXGN(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_esf_lxgn, null);
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

        mllfwlx = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_fwlx);
        mllgnlx = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_gnlx);
        mtvfwlx = (TextView) mMenuView.findViewById(R.id.tv_fwqk_fwlx);
        mtvgnlx = (TextView) mMenuView.findViewById(R.id.tv_fwqk_gnlx);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllfwlx.setOnClickListener(this);
        mllgnlx.setOnClickListener(this);

        tabfwlx = mtbbody.newTab().setCustomView(mllfwlx);
        tabgnlx = mtbbody.newTab().setCustomView(mllgnlx);
        mtbbody.addTab(tabfwlx);
        mtbbody.addTab(tabgnlx);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vfwlx = inflater.inflate(R.layout.fragment_fwlx, null);
        View vgnlx = inflater.inflate(R.layout.fragment_gnlx, null);
        viewList.add(vfwlx);
        viewList.add(vgnlx);

        mwvfwlx = (WheelView) vfwlx.findViewById(R.id.wvfwlx);
        mwvgnlx = (WheelView) vgnlx.findViewById(R.id.wvgnlx);

        mtvlxqd = (TextView) vfwlx.findViewById(R.id.tv_fwlx_qd);
        mtvgnlxqd = (TextView) vgnlx.findViewById(R.id.tv_gnlx_qd);

        mtvlxqd.setOnClickListener(this);
        mtvgnlxqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "fwlx")
            mllfwlx.performClick();
        if(type == "gnlx")
            mllgnlx.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_fwqk_fwlx:
                mtvfwlx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvfwlx.setTextColor(Color.parseColor("#bc6ba6"));
                mtvgnlx.setHintTextColor(Color.parseColor("#999999"));
                mtvgnlx.setTextColor(Color.parseColor("#000000"));
                tabfwlx.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.ll_fwqk_gnlx:
                mtvfwlx.setHintTextColor(Color.parseColor("#999999"));
                mtvfwlx.setTextColor(Color.parseColor("#000000"));
                mtvgnlx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvgnlx.setTextColor(Color.parseColor("#bc6ba6"));
                tabgnlx.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.tv_fwlx_qd:
                mtvfwlx.setText(WheelStyle.createFWLXString().get(mwvfwlx.getCurrentItem()));
                mllgnlx.performClick();
                break;
            case R.id.tv_gnlx_qd:
                mtvgnlx.setText(WheelStyle.createGNLXString().get(mwvgnlx.getCurrentItem()));
                mllfwlx.performClick();
                break;
        }
    }
}
