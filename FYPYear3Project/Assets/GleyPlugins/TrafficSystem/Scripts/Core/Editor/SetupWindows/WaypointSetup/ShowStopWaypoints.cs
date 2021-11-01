﻿using UnityEngine;

namespace GleyTrafficSystem
{
    public class ShowStopWaypoints : ShowWaypointsBase
    {
        public override ISetupWindow Initialize(WindowProperties windowProperties)
        {
            save = SettingsLoader.LoadStopdWaypointsSave();
            return base.Initialize(windowProperties);
        }


        public override void DrawInScene()
        {
            waypointsOfInterest = WaypointDrawer.ShowStopWaypoints(roadColors.waypointColor, save.showConnections, roadColors.waypointColor, save.showSpeed, roadColors.speedColor, save.showCars, roadColors.carsColor, save.showOtherLanes, roadColors.laneChangeColor);
            base.DrawInScene();
        }


        protected override void ScrollPart(float width, float height)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUILayout.Width(width - SCROLL_SPACE), GUILayout.Height(height - scrollAdjustment));
            base.ScrollPart(width, height);
            GUILayout.EndScrollView();
        }


        public override void DestroyWindow()
        {
            SettingsLoader.SaveStopWaypointsSettings(save, roadColors);
            base.DestroyWindow();
        }
    }
}
