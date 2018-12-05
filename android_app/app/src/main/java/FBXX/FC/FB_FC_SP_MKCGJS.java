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

public class FB_FC_SP_MKCGJS extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllmk; //面宽
    private ViewGroup mllcg; //层高
    private ViewGroup mlljs; //进深
    public TextView mtvmk; //面宽
    public TextView mtvcg; //层高
    public TextView mtvjs; //进深
    private TabLayout.Tab tabmk; //面宽
    private TabLayout.Tab tabcg; //层高
    private TabLayout.Tab tabjs; //进深
    private TextView mtvmkqd; //面宽
    private TextView mtvcgqd; //层高
    private TextView mtvjsqd; //进深
    private TabLayout mtbbody;
    private ViewPager mvpbody;

    public FB_FC_SP_MKCGJS(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_sp_mkcgjs, null);
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

        mllmk = (ViewGroup) mMenuView.findViewById(R.id.ll_sp_mk);
        mllcg = (ViewGroup) mMenuView.findViewById(R.id.ll_sp_cg);
        mlljs = (ViewGroup) mMenuView.findViewById(R.id.ll_sp_js);
        mtvmk = (TextView) mMenuView.findViewById(R.id.tv_sp_mk);
        mtvcg = (TextView) mMenuView.findViewById(R.id.tv_sp_cg);
        mtvjs = (TextView) mMenuView.findViewById(R.id.tv_sp_js);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllmk.setOnClickListener(this);
        mllcg.setOnClickListener(this);
        mlljs.setOnClickListener(this);

        tabmk = mtbbody.newTab().setCustomView(mllmk);
        tabcg = mtbbody.newTab().setCustomView(mllcg);
        tabjs = mtbbody.newTab().setCustomView(mlljs);
        mtbbody.addTab(tabmk);
        mtbbody.addTab(tabcg);
        mtbbody.addTab(tabjs);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vmk = inflater.inflate(R.layout.fragment_mk, null);
        View vcg = inflater.inflate(R.layout.fragment_cg, null);
        View vjs = inflater.inflate(R.layout.fragment_js, null);
        viewList.add(vmk);
        viewList.add(vcg);
        viewList.add(vjs);

        vmk.findViewById(R.id.tv_mk_0).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_1).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_2).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_3).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_4).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_5).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_6).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_7).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_8).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_9).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_point).setOnClickListener(this);
        vmk.findViewById(R.id.tv_mk_sc).setOnClickListener(this);

        vcg.findViewById(R.id.tv_cg_0).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_1).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_2).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_3).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_4).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_5).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_6).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_7).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_8).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_9).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_point).setOnClickListener(this);
        vcg.findViewById(R.id.tv_cg_sc).setOnClickListener(this);

        vjs.findViewById(R.id.tv_js_0).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_1).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_2).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_3).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_4).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_5).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_6).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_7).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_8).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_9).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_point).setOnClickListener(this);
        vjs.findViewById(R.id.tv_js_sc).setOnClickListener(this);

        mtvmkqd = (TextView) vmk.findViewById(R.id.tv_mk_qd);
        mtvcgqd = (TextView) vcg.findViewById(R.id.tv_cg_qd);
        mtvjsqd = (TextView) vjs.findViewById(R.id.tv_js_qd);

        mtvmkqd.setOnClickListener(this);
        mtvcgqd.setOnClickListener(this);
        mtvjsqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "MK")
            mllmk.performClick();
        if(type == "CG")
            mllcg.performClick();
        if(type == "JS")
            mlljs.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ll_sp_mk:
                mtvmk.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvmk.setTextColor(Color.parseColor("#bc6ba6"));
                mtvcg.setHintTextColor(Color.parseColor("#999999"));
                mtvcg.setTextColor(Color.parseColor("#000000"));
                mtvjs.setHintTextColor(Color.parseColor("#999999"));
                mtvjs.setTextColor(Color.parseColor("#000000"));
                tabmk.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.ll_sp_cg:
                mtvmk.setHintTextColor(Color.parseColor("#999999"));
                mtvmk.setTextColor(Color.parseColor("#000000"));
                mtvcg.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvcg.setTextColor(Color.parseColor("#bc6ba6"));
                mtvjs.setHintTextColor(Color.parseColor("#999999"));
                mtvjs.setTextColor(Color.parseColor("#000000"));
                tabcg.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.ll_sp_js:
                mtvmk.setHintTextColor(Color.parseColor("#999999"));
                mtvmk.setTextColor(Color.parseColor("#000000"));
                mtvcg.setHintTextColor(Color.parseColor("#999999"));
                mtvcg.setTextColor(Color.parseColor("#000000"));
                mtvjs.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvjs.setTextColor(Color.parseColor("#bc6ba6"));
                tabjs.select();
                mvpbody.setCurrentItem(2);
                break;
            case R.id.tv_mk_qd: mllcg.performClick(); break;
            case R.id.tv_cg_qd: mlljs.performClick(); break;
            case R.id.tv_mk_0: InputMK("0"); break;
            case R.id.tv_mk_1: InputMK("1"); break;
            case R.id.tv_mk_2: InputMK("2"); break;
            case R.id.tv_mk_3: InputMK("3"); break;
            case R.id.tv_mk_4: InputMK("4"); break;
            case R.id.tv_mk_5: InputMK("5"); break;
            case R.id.tv_mk_6: InputMK("6"); break;
            case R.id.tv_mk_7: InputMK("7"); break;
            case R.id.tv_mk_8: InputMK("8"); break;
            case R.id.tv_mk_9: InputMK("9"); break;
            case R.id.tv_mk_point: InputMK("."); break;
            case R.id.tv_mk_sc: DeleteMK(); break;
            case R.id.tv_cg_0: InputCG("0"); break;
            case R.id.tv_cg_1: InputCG("1"); break;
            case R.id.tv_cg_2: InputCG("2"); break;
            case R.id.tv_cg_3: InputCG("3"); break;
            case R.id.tv_cg_4: InputCG("4"); break;
            case R.id.tv_cg_5: InputCG("5"); break;
            case R.id.tv_cg_6: InputCG("6"); break;
            case R.id.tv_cg_7: InputCG("7"); break;
            case R.id.tv_cg_8: InputCG("8"); break;
            case R.id.tv_cg_9: InputCG("9"); break;
            case R.id.tv_cg_point: InputCG("."); break;
            case R.id.tv_cg_sc: DeleteCG(); break;
            case R.id.tv_js_0: InputJS("0"); break;
            case R.id.tv_js_1: InputJS("1"); break;
            case R.id.tv_js_2: InputJS("2"); break;
            case R.id.tv_js_3: InputJS("3"); break;
            case R.id.tv_js_4: InputJS("4"); break;
            case R.id.tv_js_5: InputJS("5"); break;
            case R.id.tv_js_6: InputJS("6"); break;
            case R.id.tv_js_7: InputJS("7"); break;
            case R.id.tv_js_8: InputJS("8"); break;
            case R.id.tv_js_9: InputJS("9"); break;
            case R.id.tv_js_point: InputJS("."); break;
            case R.id.tv_js_sc: DeleteJS(); break;
        }
    }

    //输入
    public void InputMK(String value) {
        if(mtvmk.getText().toString() == "") mtvmk.setText(value + "m");
        else mtvmk.setText(mtvmk.getText().toString().replaceAll("m","") + value + "m");
    }
    //删除
    public void DeleteMK() {
        if(mtvmk.length() == 2) mtvmk.setText("");
        else mtvmk.setText(mtvmk.getText().toString().substring(0, mtvmk.length() - 2) + "m");
    }
    //输入
    public void InputCG(String value) {
        if(mtvcg.getText().toString() == "") mtvcg.setText(value + "m");
        else mtvcg.setText(mtvcg.getText().toString().replaceAll("m","") + value + "m");
    }
    //删除
    public void DeleteCG() {
        if(mtvcg.length() == 2) mtvcg.setText("");
        else mtvcg.setText(mtvcg.getText().toString().substring(0, mtvcg.length() - 2) + "m");
    }
    //输入
    public void InputJS(String value) {
        if(mtvjs.getText().toString() == "") mtvjs.setText(value + "m");
        else mtvjs.setText(mtvjs.getText().toString().replaceAll("m","") + value + "m");
    }
    //删除
    public void DeleteJS() {
        if(mtvjs.length() == 2) mtvjs.setText("");
        else mtvjs.setText(mtvjs.getText().toString().substring(0, mtvmk.length() - 2) + "m");
    }
}
