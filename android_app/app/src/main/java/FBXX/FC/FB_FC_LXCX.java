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

public class FB_FC_LXCX extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllwslx; //卧室类型
    private ViewGroup mllwscx; //卧室朝向
    public TextView mtvwslx; //卧室类型
    public TextView mtvwscx; //卧室朝向
    private TabLayout.Tab tabwslx; //卧室类型
    private TabLayout.Tab tabwscx; //卧室朝向
    private TextView mtvlxqd; //卧室类型
    private TextView mtvcxqd; //卧室朝向
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvwslx;//卧室类型
    public WheelView mwvwscx;//卧室朝向

    public FB_FC_LXCX(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_lxcx, null);
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

        mllwslx = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_wslx);
        mllwscx = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_cx);
        mtvwslx = (TextView) mMenuView.findViewById(R.id.tv_fwqk_wslx);
        mtvwscx = (TextView) mMenuView.findViewById(R.id.tv_fwqk_cx);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllwslx.setOnClickListener(this);
        mllwscx.setOnClickListener(this);

        tabwslx = mtbbody.newTab().setCustomView(mllwslx);
        tabwscx = mtbbody.newTab().setCustomView(mllwscx);
        mtbbody.addTab(tabwslx);
        mtbbody.addTab(tabwscx);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vwslx = inflater.inflate(R.layout.fragment_wslx, null);
        View vwscx = inflater.inflate(R.layout.fragment_cx, null);
        viewList.add(vwslx);
        viewList.add(vwscx);

        mwvwslx = (WheelView) vwslx.findViewById(R.id.wvwslx);
        mwvwscx = (WheelView) vwscx.findViewById(R.id.wvcx);

        mtvlxqd = (TextView) vwslx.findViewById(R.id.tv_wslx_qd);
        mtvcxqd = (TextView) vwscx.findViewById(R.id.tv_cx_qd);

        mtvlxqd.setOnClickListener(this);
        mtvcxqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "WSLX")
            mllwslx.performClick();
        if(type == "WSCX")
            mllwscx.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_fwqk_wslx:
                mtvwslx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvwslx.setTextColor(Color.parseColor("#bc6ba6"));
                mtvwscx.setHintTextColor(Color.parseColor("#999999"));
                mtvwscx.setTextColor(Color.parseColor("#000000"));
                tabwslx.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.ll_fwqk_cx:
                mtvwslx.setHintTextColor(Color.parseColor("#999999"));
                mtvwslx.setTextColor(Color.parseColor("#000000"));
                mtvwscx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvwscx.setTextColor(Color.parseColor("#bc6ba6"));
                tabwscx.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.tv_wslx_qd:
                mtvwslx.setText(WheelStyle.createWSLXString().get(mwvwslx.getCurrentItem()));
                mllwscx.performClick();
                break;
            case R.id.tv_cx_qd:
                mtvwscx.setText(WheelStyle.createCXString().get(mwvwscx.getCurrentItem()));
                mllwslx.performClick();
                break;
        }
    }
}
