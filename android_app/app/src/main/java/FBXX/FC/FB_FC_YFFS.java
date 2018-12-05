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
import Common.WheelView;

public class FB_FC_YFFS extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllyffs; //押付方式
    public TextView mtvyffs; //押付方式
    private TabLayout.Tab tabyffs; //押付方式
    private TextView mtvyffsqd; //押付方式
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvy; //押
    public WheelView mwvf; //付

    public FB_FC_YFFS(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_yffs, null);
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

        mllyffs = (ViewGroup) mMenuView.findViewById(R.id.ll_fwqk_yffs);
        mtvyffs = (TextView) mMenuView.findViewById(R.id.tv_fwqk_yffs);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllyffs.setOnClickListener(this);

        tabyffs = mtbbody.newTab().setCustomView(mllyffs);

        mtbbody.addTab(tabyffs);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vyffs = inflater.inflate(R.layout.fragment_yffs, null);
        viewList.add(vyffs);

        mwvy = (WheelView) vyffs.findViewById(R.id.wvy);
        mwvf = (WheelView) vyffs.findViewById(R.id.wvf);

        mtvyffsqd = (TextView) vyffs.findViewById(R.id.tv_yffs_qd);

        mtvyffsqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        mllyffs.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_fwqk_yffs:
                mtvyffs.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvyffs.setTextColor(Color.parseColor("#bc6ba6"));
                tabyffs.select();
                mvpbody.setCurrentItem(0);
                break;
        }
    }
}
