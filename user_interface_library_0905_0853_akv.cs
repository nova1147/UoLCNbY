// 代码生成时间: 2025-09-05 08:53:01
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// 用户界面组件库
public class UserInterfaceLibrary
{
    // 定义一个组件库容器，用于存储和管理用户界面组件
    private Dictionary<string, Control> components;

    public UserInterfaceLibrary()
    {
        // 初始化组件容器
        components = new Dictionary<string, Control>();
    }

    // 添加组件到库中
    public void AddComponent(string name, Control component)
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component), "Component cannot be null.");
        }

        if (components.ContainsKey(name))
        {
            throw new ArgumentException("Component with the same name already exists.", nameof(name));
        }

        components.Add(name, component);
    }

    // 从库中移除组件
    public void RemoveComponent(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        if (!components.ContainsKey(name))
        {
            throw new KeyNotFoundException("Component not found.");
        }

        components.Remove(name);
    }

    // 获取组件
    public Control GetComponent(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        if (!components.ContainsKey(name))
        {
            throw new KeyNotFoundException("Component not found.");
        }

        return components[name];
    }

    // 显示所有组件的名称和类型
    public void DisplayComponents()
    {
        foreach (var component in components)
        {
            Console.WriteLine($"Name: {component.Key}, Type: {component.Value.GetType().Name}");
        }
    }
}
