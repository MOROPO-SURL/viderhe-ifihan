using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context;
using System.Linq;
using Xamarin.Forms;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Providers
{
    public static class PlacardOverviewProvider
    {
        public static View GetPlacardOverview(this Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind playerOrientationSupportKind)
        {
            var descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(model.Template.Id);

            var templateViewModel = TemplateViewModelProvider.Instance.GetViewModels(playerOrientationSupportKind).First(item => item.Id == descriptor.Id);

            if (model.Template.Id == PictureSecuenceTemplateDescriptor.ID)
            {
                var overviewContent = new Grid { ColumnSpacing = 0, RowSpacing = 0 };

                overviewContent.RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition(),
                    new RowDefinition()
                };
                overviewContent.ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition(),
                    new ColumnDefinition()
                };

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PictureSecuencePlacardContextModel>(model.SerializedContext);

                var iterationCount = context.Images.Length;

                if (iterationCount > 4)
                {
                    iterationCount = 4;
                }

                for (int i = 0; i < iterationCount; i++)
                {
                    var iterationImage = new Image
                    {
                        Source = ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.Images[i].ThumbnailId)),
                        Aspect = Aspect.AspectFill
                    };

                    switch (i)
                    {
                        case 0:
                            Grid.SetColumn(iterationImage, 0);
                            Grid.SetRow(iterationImage, 0);

                            break;

                        case 1:
                            Grid.SetColumn(iterationImage, 1);
                            Grid.SetRow(iterationImage, 0);

                            break;

                        case 2:
                            Grid.SetColumn(iterationImage, 0);
                            Grid.SetRow(iterationImage, 1);

                            break;

                        case 3:
                            Grid.SetColumn(iterationImage, 1);
                            Grid.SetRow(iterationImage, 1);

                            break;
                    }

                    overviewContent.Children.Add(iterationImage);
                }

                var templateIdentityImage = new Image
                {
                    Source = templateViewModel.ThumbnailImageSource
                };

                Grid.SetColumnSpan(templateIdentityImage, 2);
                Grid.SetRowSpan(templateIdentityImage, 2);

                overviewContent.Children.Add(templateIdentityImage);

                return new ContentView
                {
                    BackgroundColor = Color.Black,
                    Content = overviewContent
                };
            }

            if (model.Template.Id == SimpleVideoTemplateDescriptor.ID)
            {
                var overviewContent = new Grid();

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimpleVideoPlacardContextModel>(model.SerializedContext);

                overviewContent.Children.Add(new Image
                {
                    Source = ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.ThumbnailId))
                });
                overviewContent.Children.Add(new Image
                {
                    Source = templateViewModel.ThumbnailImageSource
                });

                return new ContentView
                {
                    BackgroundColor = Color.Black,
                    Content = overviewContent
                };
            }

            if (model.Template.Id == SimplePictureTemplateDescriptor.ID)
            {
                var overviewContent = new Grid();

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SimplePicturePlacardContextModel>(model.SerializedContext);

                overviewContent.Children.Add(new Image
                {
                    Source = ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.Image.ThumbnailId)),
                    Aspect = context.Aspect
                });
                overviewContent.Children.Add(new Image
                {
                    Source = templateViewModel.ThumbnailImageSource
                });

                return new ContentView
                {
                    BackgroundColor = Color.Black,
                    Content = overviewContent
                };
            }

            if (model.Template.Id == ResponsivePictureTemplateDescriptor.ID)
            {
                var overviewContent = new Grid();

                overviewContent.ColumnDefinitions.Add(new ColumnDefinition());
                overviewContent.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                overviewContent.ColumnDefinitions.Add(new ColumnDefinition());

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsivePicturePlacardContextModel>(model.SerializedContext);

                var imageView = new Image
                {
                    Source = ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.Image.ThumbnailId)),
                    Aspect = Aspect.AspectFill
                };

                Grid.SetColumn(imageView, 1);

                overviewContent.Children.Add(imageView);

                var templateThumbnailImageView = new Image
                {
                    Source = templateViewModel.ThumbnailImageSource
                };

                Grid.SetColumn(templateThumbnailImageView, 1);

                overviewContent.Children.Add(templateThumbnailImageView);

                return new ContentView
                {
                    BackgroundColor = Color.White,
                    Content = overviewContent
                };
            }

            if (model.Template.Id == PicturePresentingPictureLandscapeTemplateDescriptor.ID)
            {
                var overviewContent = new Grid();

                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<PicturePresentingPictureLandscapePlacardContextModel>(model.SerializedContext);

                overviewContent.Children.Add(new Image
                {
                    Source = ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(cloudServerProvider, context.PresentedImage.ThumbnailId)),
                    Aspect = Aspect.AspectFill
                });
                overviewContent.Children.Add(new Image
                {
                    Source = templateViewModel.ThumbnailImageSource
                });

                return new ContentView
                {
                    BackgroundColor = Color.Black,
                    Content = overviewContent
                };
            }

            throw new System.InvalidOperationException();
        }
    }
}
