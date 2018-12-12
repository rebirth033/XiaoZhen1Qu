package FBXX.CL;

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
import Common.WheelView;

public class FB_CL_JC_GHCS extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllghcs; //过户次数
    public TextView mtvghcs; //过户次数
    private TabLayout.Tab tabghcs; //过户次数
    private TextView mtvghcsqd; //过户次数
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvghcs; //过户次数

    public FB_CL_JC_GHCS(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_cl_jc_ghcs, null);
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

        mllghcs = (ViewGroup) mMenuView.findViewById(R.id.ll_cl_ghcs);
        mtvghcs = (TextView) mMenuView.findViewById(R.id.tv_cl_ghcs);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllghcs.setOnClickListener(this);

        tabghcs = mtbbody.newTab().setCustomView(mllghcs);

        mtbbody.addTab(tabghcs);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vghcs = inflater.inflate(R.layout.fragment_ghcs, null);
        viewList.add(vghcs);

        mwvghcs = (WheelView) vghcs.findViewById(R.id.wvghcs);

        mtvghcsqd = (TextView) vghcs.findViewById(R.id.tv_ghcs_qd);

        mtvghcsqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        mllghcs.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_cl_ghcs:
                mtvghcs.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvghcs.setTextColor(Color.parseColor("#bc6ba6"));
                tabghcs.select();
                mvpbody.setCurrentItem(0);
                break;
        }
    }
}
