package FBXX.FC;

import android.os.Bundle;
import android.view.View;
import com.example.administrator.Public.R;
import COMMON.Base;

public class Fragment_CX extends Base implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fragment_cx);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.wvs:

                break;
        }
    }

}