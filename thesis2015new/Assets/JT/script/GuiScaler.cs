using UnityEngine;
using System.Collections;

public class GuiScaler
{
	
	#region public property
	
	
	
	#endregion
	
	#region private property
	
	float _scale;
	Vector2 _offset;
	
	#endregion
	
	#region constructer
	
	public GuiScaler (
		int fixWidth = 640, 
		int fixHeight = 960, 
		bool isPortrait = false
		)
	{
		Calc (fixWidth, fixHeight, isPortrait);
	}
	
	#endregion
	
	#region private method
	
	void Calc (int w, int h, bool portrait)
	{
		
		float width = portrait ? h : w;
		float height = portrait ? w : h;
		
		float target_aspect = width / height;
		float window_aspect = (float)Screen.width / (float)Screen.height;
		float scale = window_aspect / target_aspect;
		
		Rect _rect = new Rect (0.0f, 0.0f, 1.0f, 1.0f);
		if (1.0f > scale) {
			_rect.x = 0;
			_rect.width = 1.0f;
			_rect.y = (1.0f - scale) / 2.0f;
			_rect.height = scale;
			
			_scale = (float)Screen.width / width;
		} else {
			scale = 1.0f / scale;
			_rect.x = (1.0f - scale) / 2.0f;
			_rect.width = scale;
			_rect.y = 0.0f;
			_rect.height = 1.0f;
			
			_scale = (float)Screen.height / height;
		}
		
		_offset.x = _rect.x * Screen.width;
		_offset.y = _rect.y * Screen.height;
		
	}
	
	#endregion
	
	#region public method
	
	
	
	public Rect GetRect (float x, float y, float width, float height)
	{ 
		
		
		Rect rect 
			= new Rect 
				(
					_offset.x + (x * _scale),
					_offset.y + (y * _scale), 
					width * _scale, 
					height * _scale
					);
		
		return rect;
		
	}
	
	public Rect GetRect (Rect rect)
	{
		return GetRect (rect.x, rect.y, rect.width, rect.height);
	}
	
	public Rect GetRectHalf (float x, float y, float width, float height)
	{
		
		
		
		Rect rect 
			= new Rect 
				(
					(_offset.x + (x * _scale)) / 2,
					(_offset.y + (y * _scale)) / 2, 
					(width * _scale) / 2, 
					(height * _scale) / 2
					);
		
		return rect;
		
	}
	
	public Rect GetRectHalf (Rect rect)
	{
		return GetRectHalf (rect.x, rect.y, rect.width, rect.height);	
	}
	
	#endregion
	
	
	
}