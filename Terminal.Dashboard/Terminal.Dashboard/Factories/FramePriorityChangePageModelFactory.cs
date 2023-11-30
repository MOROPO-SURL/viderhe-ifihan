using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Factories
{
    public static class FramePriorityChangePageModelFactory
    {
        public static Models.Page.FramePriorityChangePageModel Build(FrameViewModel[] frames, FrameViewModel target)
        {
            var framePick = new System.Collections.Generic.List<FrameViewModel>();

            foreach (var item in frames)
            {
                if (item.Priority < target.Priority)
                {
                    if (item.Id != target.Id)
                    {
                        framePick.Add(new FrameViewModel
                        {
                            Priority = item.Priority
                        });
                    }
                }

                framePick.Add(item);

                if (item.Priority > target.Priority)
                {
                    if (item.Id != target.Id)
                    {
                        framePick.Add(new FrameViewModel
                        {
                            Priority = item.Priority
                        });
                    }
                }
            }

            return new Models.Page.FramePriorityChangePageModel
            {
                Frames = framePick.ToArray(),
                Target = target
            };
        }
    }
}
