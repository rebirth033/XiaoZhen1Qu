package FBXX.CL;

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
import com.example.administrator.Public.R;
import java.util.ArrayList;
import java.util.List;
import Common.ViewAdapter;
import Common.WheelView;

public class FB_CL_CCNX extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllccnx; //出厂年限
    public TextView mtvccnx; //出厂年限
    private TabLayout.Tab tabccnx; //出厂年限
    private TextView mtvccnxqd; //出厂年限
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvyear;//年
    public WheelView mwvmonth;//月

    public FB_CL_CCNX(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_cl_ccnx, null);
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
        initView(itemsOnClick,context);
    }

    //初始化页面
    private void initView(View.OnClickListener itemsOnClick, Activity context) {

        mtvccnx = (TextView) mMenuView.findViewById(R.id.tv_ccnx);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllccnx = (ViewGroup)mMenuView.findViewById(R.id.ll_ccnx);

        mllccnx.setOnClickListener(this);

        tabccnx = mtbbody.newTab().setCustomView(mllccnx);
        mtbbody.addTab(tabccnx);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vts = inflater.inflate(R.layout.fragment_ccnx, null);
        viewList.add(vts);

        mwvyear = (WheelView) vts.findViewById(R.id.wvyear);
        mwvmonth = (WheelView) vts.findViewById(R.id.wvmonth);

        mtvccnxqd = (TextView) vts.findViewById(R.id.tv_ccnx_qd);

        mtvccnxqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        mllccnx.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_ccnx:
                mtvccnx.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvccnx.setTextColor(Color.parseColor("#bc6ba6"));
                tabccnx.select();
                mvpbody.setCurrentItem(0);
                break;
//            case R.id.tv_zxqk_qd:
//                mtvzxqk.setText(WheelStyle.createZXQKString().get(mwvzxqk.getCurrentItem()));
//                mllccnx.performClick();
//                break;
        }
    }
}
