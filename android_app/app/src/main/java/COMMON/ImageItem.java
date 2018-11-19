package Common;

import android.graphics.Bitmap;

import java.io.Serializable;

//从图库选择的图片model
public class ImageItem implements Serializable {

    public String imageId; //图片id
    public String thumbnailPath;
    public String imagePath; //图片路径
    private Bitmap bitmap;
    public boolean isSelected = false;

    public String getImageId() {
        return imageId;
    }

    public void setImageId(String imageId) {
        this.imageId = imageId;
    }

    public String getThumbnailPath() {
        return thumbnailPath;
    }

    public void setThumbnailPath(String thumbnailPath) {
        this.thumbnailPath = thumbnailPath;
    }

    public String getImagePath() {
        return imagePath;
    }

    public void setImagePath(String imagePath) {
        this.imagePath = imagePath;
    }

    public boolean isSelected() {
        return isSelected;
    }

    public void setSelected(boolean isSelected) {
        this.isSelected = isSelected;
    }
}