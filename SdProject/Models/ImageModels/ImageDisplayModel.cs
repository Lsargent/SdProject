using Logic;

namespace SdProject.Models.ImageModels {
    public class ImageDisplayModel {
        public ImageDisplayModel() {
        }

        public ImageDisplayModel(Image image) {
            ImageId = image.Id;
            Url = image.Url;
        }

        public int ImageId { get; set; }

        public string Url { get; set; }
    }
}