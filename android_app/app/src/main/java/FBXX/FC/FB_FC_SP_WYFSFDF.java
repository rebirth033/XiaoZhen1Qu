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

public class FB_FC_SP_WYFSFDF extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllwyf; //物业费
    private ViewGroup mllsf; //水费
    private ViewGroup mlldf; //电费
    public TextView mtvwyf; //物业费
    public TextView mtvsf; //水费
    public TextView mtvdf; //电费
    private TabLayout.Tab tabwyf; //物业费
    private TabLayout.Tab tabsf; //水费
    private TabLayout.Tab tabdf; //电费
    private TextView mtvwyfqd; //物业费
    private TextView mtvsfqd; //水费
    private TextView mtvdfqd; //电费
    private TabLayout mtbbody;
    private ViewPager mvpbody;

    public FB_FC_SP_WYFSFDF(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_sp_wyfsfdf, null);
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

        mllwyf = (ViewGroup) mMenuView.findViewById(R.id.ll_sp_wyf);
        mllsf = (ViewGroup) mMenuView.findViewById(R.id.ll_sp_sf);
        mlldf = (ViewGroup) mMenuView.findViewById(R.id.ll_sp_df);
        mtvwyf = (TextView) mMenuView.findViewById(R.id.tv_sp_wyf);
        mtvsf = (TextView) mMenuView.findViewById(R.id.tv_sp_sf);
        mtvdf = (TextView) mMenuView.findViewById(R.id.tv_sp_df);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllwyf.setOnClickListener(this);
        mllsf.setOnClickListener(this);
        mlldf.setOnClickListener(this);

        tabwyf = mtbbody.newTab().setCustomView(mllwyf);
        tabsf = mtbbody.newTab().setCustomView(mllsf);
        tabdf = mtbbody.newTab().setCustomView(mlldf);
        mtbbody.addTab(tabwyf);
        mtbbody.addTab(tabsf);
        mtbbody.addTab(tabdf);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vwyf = inflater.inflate(R.layout.fragment_wyf, null);
        View vsf = inflater.inflate(R.layout.fragment_sf, null);
        View vdf = inflater.inflate(R.layout.fragment_df, null);
        viewList.add(vwyf);
        viewList.add(vsf);
        viewList.add(vdf);

        vwyf.findViewById(R.id.tv_wyf_0).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_1).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_2).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_3).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_4).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_5).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_6).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_7).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_8).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_9).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_point).setOnClickListener(this);
        vwyf.findViewById(R.id.tv_wyf_sc).setOnClickListener(this);

        vsf.findViewById(R.id.tv_sf_0).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_1).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_2).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_3).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_4).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_5).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_6).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_7).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_8).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_9).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_point).setOnClickListener(this);
        vsf.findViewById(R.id.tv_sf_sc).setOnClickListener(this);

        vdf.findViewById(R.id.tv_df_0).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_1).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_2).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_3).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_4).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_5).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_6).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_7).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_8).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_9).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_point).setOnClickListener(this);
        vdf.findViewById(R.id.tv_df_sc).setOnClickListener(this);

        mtvwyfqd = (TextView) vwyf.findViewById(R.id.tv_wyf_qd);
        mtvsfqd = (TextView) vsf.findViewById(R.id.tv_sf_qd);
        mtvdfqd = (TextView) vdf.findViewById(R.id.tv_df_qd);

        mtvwyfqd.setOnClickListener(this);
        mtvsfqd.setOnClickListener(this);
        mtvdfqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "wyf")
            mllwyf.performClick();
        if(type == "sf")
            mllsf.performClick();
        if(type == "df")
            mlldf.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_sp_wyf:
                mtvwyf.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvwyf.setTextColor(Color.parseColor("#bc6ba6"));
                mtvsf.setHintTextColor(Color.parseColor("#999999"));
                mtvsf.setTextColor(Color.parseColor("#000000"));
                mtvdf.setHintTextColor(Color.parseColor("#999999"));
                mtvdf.setTextColor(Color.parseColor("#000000"));
                tabwyf.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.ll_sp_sf:
                mtvwyf.setHintTextColor(Color.parseColor("#999999"));
                mtvwyf.setTextColor(Color.parseColor("#000000"));
                mtvsf.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvsf.setTextColor(Color.parseColor("#bc6ba6"));
                mtvdf.setHintTextColor(Color.parseColor("#999999"));
                mtvdf.setTextColor(Color.parseColor("#000000"));
                tabsf.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.ll_sp_df:
                mtvwyf.setHintTextColor(Color.parseColor("#999999"));
                mtvwyf.setTextColor(Color.parseColor("#000000"));
                mtvsf.setHintTextColor(Color.parseColor("#999999"));
                mtvsf.setTextColor(Color.parseColor("#000000"));
                mtvdf.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvdf.setTextColor(Color.parseColor("#bc6ba6"));
                tabdf.select();
                mvpbody.setCurrentItem(2);
                break;
            case R.id.tv_wyf_qd: mllsf.performClick(); break;
            case R.id.tv_sf_qd: mlldf.performClick(); break;
            case R.id.tv_wyf_0: Inputwyf("0"); break;
            case R.id.tv_wyf_1: Inputwyf("1"); break;
            case R.id.tv_wyf_2: Inputwyf("2"); break;
            case R.id.tv_wyf_3: Inputwyf("3"); break;
            case R.id.tv_wyf_4: Inputwyf("4"); break;
            case R.id.tv_wyf_5: Inputwyf("5"); break;
            case R.id.tv_wyf_6: Inputwyf("6"); break;
            case R.id.tv_wyf_7: Inputwyf("7"); break;
            case R.id.tv_wyf_8: Inputwyf("8"); break;
            case R.id.tv_wyf_9: Inputwyf("9"); break;
            case R.id.tv_wyf_point: Inputwyf("."); break;
            case R.id.tv_wyf_sc: Deletewyf(); break;
            case R.id.tv_sf_0: Inputsf("0"); break;
            case R.id.tv_sf_1: Inputsf("1"); break;
            case R.id.tv_sf_2: Inputsf("2"); break;
            case R.id.tv_sf_3: Inputsf("3"); break;
            case R.id.tv_sf_4: Inputsf("4"); break;
            case R.id.tv_sf_5: Inputsf("5"); break;
            case R.id.tv_sf_6: Inputsf("6"); break;
            case R.id.tv_sf_7: Inputsf("7"); break;
            case R.id.tv_sf_8: Inputsf("8"); break;
            case R.id.tv_sf_9: Inputsf("9"); break;
            case R.id.tv_sf_point: Inputsf("."); break;
            case R.id.tv_sf_sc: Deletesf(); break;
            case R.id.tv_df_0: Inputdf("0"); break;
            case R.id.tv_df_1: Inputdf("1"); break;
            case R.id.tv_df_2: Inputdf("2"); break;
            case R.id.tv_df_3: Inputdf("3"); break;
            case R.id.tv_df_4: Inputdf("4"); break;
            case R.id.tv_df_5: Inputdf("5"); break;
            case R.id.tv_df_6: Inputdf("6"); break;
            case R.id.tv_df_7: Inputdf("7"); break;
            case R.id.tv_df_8: Inputdf("8"); break;
            case R.id.tv_df_9: Inputdf("9"); break;
            case R.id.tv_df_point: Inputdf("."); break;
            case R.id.tv_df_sc: Deletedf(); break;
        }
    }

    //输入
    public void Inputwyf(String value) {
        if(mtvwyf.getText().toString() == "") mtvwyf.setText(value + "元/㎡/天");
        else mtvwyf.setText(mtvwyf.getText().toString().replaceAll("元/㎡/天","") + value + "元/㎡/天");
    }
    //删除
    public void Deletewyf() {
        if(mtvwyf.length() == 6) mtvwyf.setText("");
        else mtvwyf.setText(mtvwyf.getText().toString().substring(0, mtvwyf.length() - 6) + "元/㎡/天");
    }
    //输入
    public void Inputsf(String value) {
        if(mtvsf.getText().toString() == "") mtvsf.setText(value + "元/吨");
        else mtvsf.setText(mtvsf.getText().toString().replaceAll("元/吨","") + value + "元/吨");
    }
    //删除
    public void Deletesf() {
        if(mtvsf.length() == 4) mtvsf.setText("");
        else mtvsf.setText(mtvsf.getText().toString().substring(0, mtvsf.length() - 4) + "元/吨");
    }
    //输入
    public void Inputdf(String value) {
        if(mtvdf.getText().toString() == "") mtvdf.setText(value + "元/度");
        else mtvdf.setText(mtvdf.getText().toString().replaceAll("元/度","") + value + "元/度");
    }
    //删除
    public void Deletedf() {
        if(mtvdf.length() == 4) mtvdf.setText("");
        else mtvdf.setText(mtvdf.getText().toString().substring(0, mtvwyf.length() - 4) + "元/度");
    }
}
