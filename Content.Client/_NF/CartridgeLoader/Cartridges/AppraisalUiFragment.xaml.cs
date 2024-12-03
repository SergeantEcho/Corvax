using Content.Shared.CartridgeLoader.Cartridges;
using Robust.Client.AutoGenerated;
using Robust.Client.Graphics;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._NF.CartridgeLoader.Cartridges;

[GenerateTypedNameReferences]
public sealed partial class AppraisalUiFragment : BoxContainer
{
    private readonly StyleBoxFlat _styleBox = new()
    {
        BackgroundColor = Color.Transparent,
        BorderColor = Color.FromHex("#5a5a5a"),
        BorderThickness = new Thickness(0, 0, 0, 1)
    };

    public AppraisalUiFragment()
    {
        RobustXamlLoader.Load(this);
        Orientation = LayoutOrientation.Vertical;
        HorizontalExpand = true;
        VerticalExpand = true;
        HeaderPanel.PanelOverride = _styleBox;
    }

    public void UpdateState(List<AppraisedItem> items)
    {
        AppraisedItemContainer.RemoveAllChildren();

        //Reverse the list so the oldest entries appear at the bottom
        items.Reverse();

        //Enable scrolling if there are more entries that can fit on the screen
        ScrollContainer.HScrollEnabled = items.Count > 9;

        foreach (var item in items)
        {
            AddAppraisedItem(item);
        }
    }

    private void AddAppraisedItem(AppraisedItem item)
    {
        var row = new BoxContainer();
        row.HorizontalExpand = true;
        row.Orientation = LayoutOrientation.Horizontal;
        row.Margin = new Thickness(4);

        var nameLabel = new Label();
        nameLabel.Text = item.Name;
        nameLabel.HorizontalExpand = true;
        nameLabel.ClipText = true;
        row.AddChild(nameLabel);

        var valueLabel = new Label();
        valueLabel.Text = item.AppraisedPrice;
        valueLabel.HorizontalExpand = true;
        valueLabel.ClipText = true;
        row.AddChild(valueLabel);

        AppraisedItemContainer.AddChild(row);
    }
}