package FBXX.FC;

import android.os.Bundle;
import android.view.View;

import com.example.administrator.Public.R;

import COMMON.Base;

public class Fragment_TS extends Base implements View.OnClickListener {


    private WheelView mwvs; //室
    private WheelView mwvt; //厅
    private WheelView mwvw; //卫

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fragment_ts);
        mwvs = (WheelView) this.findViewById(R.id.wvs);
        mwvt = (WheelView) this.findViewById(R.id.wvt);
        mwvw = (WheelView) this.findViewById(R.id.wvw);
        mwvs.setWheelItemList(WheelStyle.createSString());
        mwvt.setWheelItemList(WheelStyle.createTString());
        mwvw.setWheelItemList(WheelStyle.createWString());
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.wvs:

                break;

        }
    }

}