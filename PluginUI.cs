
using Dalamud.Game.Chat.SeStringHandling;
using Dalamud.Plugin;
using Dalamud.Interface;
using FFXIVClientStructs;
using FFXIVClientStructs.Component.GUI;
using ImGuiNET;
using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace DeepDungeonDex
{
    public class PluginUI
    {
        public bool IsVisible { get; set; }
        private Configuration config;
        private DalamudPluginInterface pluginInterface;

        public PluginUI(Configuration config, DalamudPluginInterface pluginInterface)
        {
            this.config = config;
            this.pluginInterface = pluginInterface;
        }

        public void Draw()
        {
            if (!IsVisible)
                return;
            var mobData = DataHandler.Mobs(TargetData.NameID);
            if (mobData == null) return;

            // Get Floor number so that the MobData tips can be tailored down the line for more dangerous floors
            int? floorLowerBound = null;
            int? floorUpperBound = null;
            bool InDeepDungeon = this.pluginInterface.ClientState.Condition[Dalamud.Game.ClientState.ConditionFlag.InDeepDungeon];
            var windowTitle = "cool strati window";
            if (InDeepDungeon) { 
                unsafe
                {
                    AtkUnitBase* _ToDoListBasePtr = (AtkUnitBase*)pluginInterface.Framework.Gui.GetUiObjectByName("_ToDoList", 1);
                    AtkComponentNode* _ToDoListComponentPtr = (AtkComponentNode*)_ToDoListBasePtr->RootNode->ChildNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode;
                    AtkTextNode* dutyNamePtr = (AtkTextNode*)((_ToDoListComponentPtr->Component)->ULDData.RootNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode->PrevSiblingNode);
                    string dutyNameStr = Marshal.PtrToStringAnsi(new IntPtr(dutyNamePtr->NodeText.StringPtr));
                    string[] aDutyName = String.Join("", String.Join("",dutyNameStr.Split(')')).Split('(')).Split(' ');

                    aDutyName = aDutyName[aDutyName.Length-1].Split('-');
                    floorLowerBound = int.Parse(aDutyName[0]);
                    floorUpperBound = int.Parse(aDutyName[1]);
                }
            }

            var flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoTitleBar;
            //var flags = ImGuiWindowFlags.NoScrollbar;
            if (config.IsClickthrough)
            {
                flags |= ImGuiWindowFlags.NoInputs;
            }
            ImGui.SetNextWindowSizeConstraints(new Vector2(250, 0), new Vector2(9001, 9001));
            ImGui.SetNextWindowBgAlpha(config.Opacity);

            if (InDeepDungeon)
            {
                windowTitle += " (Floors " + floorLowerBound + "-" + floorUpperBound + ")";
            }
            ImGui.Begin(windowTitle, flags);
            ImGui.Text(TargetData.Name);
            ImGui.PopTextWrapPos();
            ImGui.SameLine();
            ImGui.Text("( ");
            ImGui.SameLine();
            // Special details column: Undead, Patrol, Blood Aggro, etc
            ImGui.PushFont(UiBuilder.IconFont);
            ImGui.Text(DataHandler.MobData.AggroTypeExtra[mobData.Aggro][0]);
            ImGui.PopFont();
            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.PushTextWrapPos(400f);
                ImGui.TextWrapped(DataHandler.MobData.AggroTypeExtra[mobData.Aggro][1]);
                ImGui.PopTextWrapPos();
                ImGui.EndTooltip();
            }
            ImGui.SameLine();
            if (mobData.IsPatrol) {
                ImGui.PushFont(UiBuilder.IconFont);
                ImGui.PushStyleColor(ImGuiCol.Text, 0xFF1249FF);
                ImGui.Text(FontAwesomeIcon.Walking.ToIconString());
                ImGui.PopStyleColor();
                ImGui.PopFont();
                if (ImGui.IsItemHovered())
                {
                    ImGui.BeginTooltip();
                    ImGui.PushTextWrapPos(400f);
                    ImGui.TextWrapped("Enemy is a patrol unit.\nDon't let it creep up on you!");
                    ImGui.PopTextWrapPos();
                    ImGui.EndTooltip();
                }
                ImGui.SameLine();
            }
            if (mobData.IsUndead) {
                ImGui.PushFont(UiBuilder.IconFont);
                ImGui.PushStyleColor(ImGuiCol.Text, 0xFFFF00FF);
                ImGui.Text(FontAwesomeIcon.Ghost.ToIconString());
                ImGui.PopStyleColor();
                ImGui.PopFont();
                if (ImGui.IsItemHovered())
                {
                    ImGui.BeginTooltip();
                    ImGui.PushTextWrapPos(400f);
                    ImGui.TextWrapped("Enemy type is Undead.\nWeak to Pomander of Resolution.");
                    ImGui.PopTextWrapPos();
                    ImGui.EndTooltip();
                }
                ImGui.SameLine();
            }
            if (mobData.IsBloodAggro)
            {
                ImGui.PushFont(UiBuilder.IconFont);
                ImGui.PushStyleColor(ImGuiCol.Text, 0xFF2300AF);
                ImGui.Text(FontAwesomeIcon.Tint.ToIconString());
                ImGui.PopStyleColor();
                ImGui.PopFont();
                if (ImGui.IsItemHovered())
                {
                    ImGui.BeginTooltip();
                    ImGui.PushTextWrapPos(400f);
                    ImGui.TextWrapped("Enemy will aggro if your HP isn't topped up.");
                    ImGui.PopTextWrapPos();
                    ImGui.EndTooltip();
                }
                ImGui.SameLine();
            }
            ImGui.Text(" )");
            ImGui.NewLine();
            
            ImGui.NewLine();
            ImGui.Columns(3, null, false);
            ImGui.Text("Aggro Type:\n");
            ImGui.PushStyleColor(ImGuiCol.Text, 0xFFB0B0B0);
            ImGui.Text(mobData.Aggro.ToString());
            ImGui.PopStyleColor();
            
            ImGui.NextColumn();
            ImGui.Text("Threat:\n");
            switch (mobData.Threat)
            {
                case DataHandler.MobData.ThreatLevel.Easy:
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFF00FF00);
                    ImGui.Text("Easy");
                    ImGui.PopStyleColor();
                    break;
                case DataHandler.MobData.ThreatLevel.Caution:
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFFFF003C);
                    ImGui.Text("Caution");
                    ImGui.PopStyleColor();
                    break;
                case DataHandler.MobData.ThreatLevel.Dangerous:
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFF0000FF);
                    ImGui.Text("Dangerous");
                    ImGui.PopStyleColor();
                    break;
                case DataHandler.MobData.ThreatLevel.Vicious:
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFFFF00FF);
                    ImGui.Text("Vicious");
                    ImGui.PopStyleColor();
                    break;
                default:
                    ImGui.Text("Undefined");
                    break;
            }
            ImGui.NextColumn();
            ImGui.Text("Can stun:\n");
            switch (mobData.IsStunnable)
            {
                case true:
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFF00FF00);
                    ImGui.Text("Yes");
                    ImGui.PopStyleColor();
                    break;
                case false:
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFF0000FF);
                    ImGui.Text("No");
                    ImGui.PopStyleColor();
                    break;
                default:
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFF919191);
                    ImGui.Text("Untested");
                    ImGui.PopStyleColor();
                    break;
            }
            ImGui.NextColumn();
            ImGui.Columns(1);
            ImGui.NewLine();
            ImGui.TextWrapped(mobData.MobNotes);
            ImGui.End();
        }
    }
}
