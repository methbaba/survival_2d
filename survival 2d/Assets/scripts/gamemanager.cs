using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class gamemanager : MonoBehaviour
    {
        //can be used for distance calculations
        public float pixel_offset = 0.01f;
        
        // for graph of the complete level based on the rendrer max width and height
        public Texture2D level_texture;
        Texture2D texture_2d_instance;
        public SpriteRenderer level_renderer;

        int max_x;
        int max_y;
       
        node[,] grid;

        // for interface 
        //change this mouse input to touch input later //
        Vector3 mousepos;
        node current_node;
        node previous_node;

        private void Start()
        {
            create_new_level();
        }

        void create_new_level() {

            max_x = level_texture.width;
            max_y = level_texture.height;
            texture_2d_instance = new Texture2D(max_x, max_y);
            

            grid = new node[max_x, max_y];

            for (int x = 0; x < max_x; x++)
            {
                for (int y = 0; y < max_y; y++)
                {
                    node n = new node();
                    n.x = x;
                    n.y = y;

                    Color c = level_texture.GetPixel(x,y);

                    texture_2d_instance.SetPixel(x, y, c);
                    n.is_empty = (c.a == 0);

                    grid[x, y] = n;
                }
            }

            texture_2d_instance.Apply();
            Rect rectangle = new Rect(0, 0, max_x, max_y);
            level_renderer.sprite = Sprite.Create(texture_2d_instance, rectangle, Vector2.zero);
        }

        private void Update()
        {
            get_mouse_postion();
            handle_mouse_input();
        }

        void handle_mouse_input()
        {
            if (current_node ==null)
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {
                if (current_node != previous_node)
                {
                    previous_node = current_node;

                    Color c = Color.white;
                    c.a = 0;
                    for (int x = -10; x < 10; x++)
                    {
                        for (int y = -10; y < 10; y++)
                        {
                            int t_x = x + current_node.x;
                            int t_y = y + current_node.y;

                            level_texture.SetPixel(t_x, t_y, c);
                        }
                    }

                    level_texture.Apply();
                }
            }
        }
        void get_mouse_postion()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            mousepos = ray.GetPoint(1);
            current_node = get_node_from_world_pos(mousepos);
        }

       node get_node_from_world_pos(Vector3 wp)
        {
            int t_x = Mathf.RoundToInt(wp.x/pixel_offset);
            int t_y = Mathf.RoundToInt(wp.y / pixel_offset);
            return get_node(t_x, t_y);
        } 
        node get_node(int x,int y)
        {
            if(x<0 || y<0 || x>max_x-1 || y > max_y - 1)
            {
                return null;
            }
            else
            {
                return grid[x, y];
            }
        }
    }

    public class node
    {
        public int x;
        public int y;


        public bool is_empty;



    }

}