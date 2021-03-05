
using Dalamud.Game.Chat.SeStringHandling;
using Dalamud.Plugin;
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

            //var flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoTitleBar;
            var flags = ImGuiWindowFlags.NoScrollbar;
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
            ImGui.Columns(2, null, false);
            ImGui.Text("Name:\n"+TargetData.Name);
            ImGui.NextColumn();
            int columnCount = (mobData.IsUndead ? 1 : 0) + (mobData.IsPatrol ? 1 : 0);
            if (columnCount > 0) {
                if (mobData.IsPatrol) {
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFF0000FF);
                    ImGui.Text("Patrol");
                    ImGui.PopStyleColor();
                }
                if (mobData.IsUndead) {
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xFFFF00FF);
                    ImGui.Text("Undead");
                    ImGui.PopStyleColor();
                }
            } else {
                ImGui.NewLine();
                ImGui.Columns(1, null, false);
            }
            
            ImGui.NewLine();
            ImGui.Columns(3, null, false);
            ImGui.Text("Aggro Type:\n");
            ImGui.Text(mobData.Aggro.ToString());
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
